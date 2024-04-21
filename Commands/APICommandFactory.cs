using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using xAPI.Codes;
using xAPI.Errors;
using xAPI.Records;
using xAPI.Responses;
using xAPI.Sync;


namespace xAPI.Commands
{
    public class APICommandFactory
    {
        private static int redirectCounter = 0;

        public static LoginCommand CreateLoginCommand(string userId, string password, bool prettyPrint = false)
        {
            return new LoginCommand(new JObject()
            {
                {
                    nameof (userId),
                    (JToken) userId
                },

                {
                    nameof (password),
                    (JToken) password
                },

                {
                    "type",
                    (JToken) "dotNET"
                },

                {
                    "version",
                    (JToken) "2.5.0"
                }
            }, 
            prettyPrint);
        }

        public static LoginCommand CreateLoginCommand(Credentials credentials, bool prettyPrint = false)
        {
            return new LoginCommand(CreateLoginJsonObject(credentials), prettyPrint);
        }

        private static JObject CreateLoginJsonObject(Credentials credentials)
        {
            JObject loginJsonObject = [];
            if (credentials != null)
            {
                loginJsonObject.Add("userId", (JToken)credentials.Login);
                loginJsonObject.Add("password", (JToken)credentials.Password);
                loginJsonObject.Add("type", (JToken)"dotNET");
                loginJsonObject.Add("version", (JToken)"2.5.0");
                
                if (credentials.AppId != null)
                    loginJsonObject.Add("appId", (JToken)credentials.AppId);
                
                if (credentials.AppName != null)
                    loginJsonObject.Add("appName", (JToken)credentials.AppName);
            }
            return loginJsonObject;
        }

        public static AllSymbolsCommand CreateAllSymbolsCommand(bool prettyPrint = false)
        {
            return new AllSymbolsCommand(prettyPrint);
        }

        public static CalendarCommand CreateCalendarCommand(bool prettyPrint = false)
        {
            return new CalendarCommand(prettyPrint);
        }

        public static ChartLastCommand CreateChartLastCommand(
          string symbol,
          PERIOD_CODE period,
          long? start,
          bool prettyPrint = false)
        {
            return new ChartLastCommand(new JObject()
      {
        {
          "info",
           new ChartLastInfoRecord(symbol, period, start).toJSONObject()
        }
      }, prettyPrint);
        }

        public static ChartLastCommand CreateChartLastCommand(
          ChartLastInfoRecord info,
          bool prettyPrint = false)
        {
            return new ChartLastCommand(new JObject()
      {
        {
          nameof (info),
          (JToken) info.toJSONObject()
        }
      }, prettyPrint);
        }

        public static ChartRangeCommand CreateChartRangeCommand(
          ChartRangeInfoRecord info,
          bool prettyPrint = false)
        {
            return new ChartRangeCommand(new JObject()
      {
        {
          nameof (info),
          (JToken) info.toJSONObject()
        }
      }, prettyPrint);
        }

        public static ChartRangeCommand CreateChartRangeCommand(
          string symbol,
          PERIOD_CODE period,
          long? start,
          long? end,
          long? ticks,
          bool prettyPrint = false)
        {
            return new ChartRangeCommand(new JObject()
      {
        {
          "info",
          (JToken) new ChartRangeInfoRecord(symbol, period, start, end, ticks).toJSONObject()
        }
      }, prettyPrint);
        }

        public static CommissionDefCommand CreateCommissionDefCommand(
          string symbol,
          double? volume,
          bool prettyPrint = false)
        {
            return new CommissionDefCommand(new JObject()
      {
        {
          nameof (symbol),
          (JToken) symbol
                },
        {
          nameof (volume),
          (JToken) volume
                }
            }, 
            prettyPrint);
        }

        public static LogoutCommand CreateLogoutCommand() => new LogoutCommand();

        public static MarginLevelCommand CreateMarginLevelCommand(bool prettyPrint = false)
        {
            return new MarginLevelCommand(new bool?(prettyPrint));
        }

        public static MarginTradeCommand CreateMarginTradeCommand(
          string symbol,
          double? volume,
          bool prettyPrint)
        {
            return new MarginTradeCommand(new JObject()
      {
        {
          nameof (symbol),
          (JToken) symbol
        },
        {
          nameof (volume),
          (JToken) volume
        }
      }, prettyPrint);
        }

        public static NewsCommand CreateNewsCommand(long? start, long? end, bool prettyPrint)
        {
            return new NewsCommand(new JObject()
      {
        {
          nameof (start),
          (JToken) start
        },
        {
          nameof (end),
          (JToken) end
        }
      }, prettyPrint);
        }

        public static ServerTimeCommand CreateServerTimeCommand(bool prettyPrint = false)
        {
            return new ServerTimeCommand(new bool?(prettyPrint));
        }

        public static CurrentUserDataCommand CreateCurrentUserDataCommand(bool prettyPrint = false)
        {
            return new CurrentUserDataCommand(prettyPrint);
        }

        public static IbsHistoryCommand CreateGetIbsHistoryCommand(
          long start,
          long end,
          bool prettyPrint = false)
        {
            return new IbsHistoryCommand(new JObject()
      {
        {
          nameof (start),
          (JToken) start
        },
        {
          nameof (end),
          (JToken) end
        }
      }, prettyPrint);
        }

        public static PingCommand CreatePingCommand(bool prettyPrint = false)
        {
            return new PingCommand(new bool?(prettyPrint));
        }

        public static ProfitCalculationCommand CreateProfitCalculationCommand(
          string symbol,
          double? volume,
          TRADE_OPERATION_CODE cmd,
          double? openPrice,
          double? closePrice,
          bool prettyPrint = false)
        {
            return new ProfitCalculationCommand(new JObject()
      {
        {
          nameof (symbol),
          (JToken) symbol
        },
        {
          nameof (volume),
          (JToken) volume
        },
        {
          nameof (cmd),
          (JToken) cmd.Code
        },
        {
          nameof (openPrice),
          (JToken) openPrice
        },
        {
          nameof (closePrice),
          (JToken) closePrice
        }
      }, prettyPrint);
        }

        [Obsolete("Command not available in API any more")]
        public static AllSymbolGroupsCommand CreateSymbolGroupsCommand(bool prettyPrint = false)
        {
            return null;
        }

        public static SymbolCommand CreateSymbolCommand(string symbol, bool prettyPrint = false)
        {
            return new SymbolCommand(new JObject()
      {
        {
          nameof (symbol),
          (JToken) symbol
        }
      }, prettyPrint);
        }

        public static StepRulesCommand CreateStepRulesCommand(bool prettyPrint = false)
        {
            return new StepRulesCommand();
        }

        public static TickPricesCommand CreateTickPricesCommand(
          List<string> symbols,
          long? timestamp,
          bool prettyPrint = false)
        {
            JObject arguments = [];
            JArray jarray = [];
            foreach (string symbol in symbols)
                jarray.Add((JToken)symbol);
            arguments.Add(nameof(symbols), (JToken)jarray);
            arguments.Add(nameof(timestamp), (JToken)timestamp);
            return new TickPricesCommand(arguments, prettyPrint);
        }

        public static TradeRecordsCommand CreateTradeRecordsCommand(
          LinkedList<long?> orders,
          bool prettyPrint = false)
        {
            JObject arguments = [];
            JArray jarray = [];
            foreach (long? order in orders)
                jarray.Add((JToken)order);
            arguments.Add(nameof(orders), (JToken)jarray);
            return new TradeRecordsCommand(arguments, prettyPrint);
        }

        public static TradeTransactionCommand CreateTradeTransactionCommand(
          TradeTransInfoRecord tradeTransInfo,
          bool prettyPrint = false)
        {
            return new TradeTransactionCommand(new JObject()
      {
        {
          nameof (tradeTransInfo),
          (JToken) tradeTransInfo.toJSONObject()
        }
      }, prettyPrint);
        }

        public static TradeTransactionCommand CreateTradeTransactionCommand(
          TRADE_OPERATION_CODE cmd,
          TRADE_TRANSACTION_TYPE type,
          double? price,
          double? sl,
          double? tp,
          string symbol,
          double? volume,
          long? order,
          string customComment,
          long? expiration,
          bool prettyPrint = false)
        {
            return new TradeTransactionCommand(new JObject()
      {
        {
          "tradeTransInfo",
          (JToken) new TradeTransInfoRecord(cmd, type, price, sl, tp, symbol, volume, order, customComment, expiration).toJSONObject()
        }
      }, prettyPrint);
        }

        [Obsolete("Method outdated. ie_deviation and comment are not available any more")]
        public static TradeTransactionCommand CreateTradeTransactionCommand(
          TRADE_OPERATION_CODE cmd,
          TRADE_TRANSACTION_TYPE type,
          double? price,
          double? sl,
          double? tp,
          string symbol,
          double? volume,
          long? ie_deviation,
          long? order,
          string comment,
          long? expiration,
          bool prettyPrint = false)
        {
            return APICommandFactory.CreateTradeTransactionCommand(cmd, type, price, sl, tp, symbol, volume, order, "", expiration);
        }

        public static TradeTransactionStatusCommand CreateTradeTransactionStatusCommand(
          long? order,
          bool prettyPrint = false)
        {
            return new TradeTransactionStatusCommand(new JObject()
      {
        {
          nameof (order),
          (JToken) order
        }
      }, prettyPrint);
        }

        public static TradesCommand CreateTradesCommand(bool openedOnly, bool prettyPrint = false)
        {
            return new TradesCommand(new JObject()
      {
        {
          nameof (openedOnly),
          (JToken) openedOnly
        }
      }, prettyPrint);
        }

        public static TradesHistoryCommand CreateTradesHistoryCommand(
          long? start,
          long? end,
          bool prettyPrint = false)
        {
            return new TradesHistoryCommand(new JObject()
      {
        {
          nameof (start),
          (JToken) start
        },
        {
          nameof (end),
          (JToken) end
        }
      }, prettyPrint);
        }

        public static TradingHoursCommand CreateTradingHoursCommand(
          List<string> symbols,
          bool prettyPrint = false)
        {
            JObject arguments = [];
            JArray jarray = [];
            foreach (string symbol in symbols)
                jarray.Add((JToken)symbol);
            arguments.Add(nameof(symbols), jarray);
            return new TradingHoursCommand(arguments, prettyPrint);
        }

        public static VersionCommand CreateVersionCommand(bool prettyPrint = false)
        {
            return new VersionCommand([], prettyPrint);
        }

        public static AllSymbolsResponse ExecuteAllSymbolsCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new AllSymbolsResponse(connector.ExecuteCommand(CreateAllSymbolsCommand(prettyPrint)).ToString());
        }

        public static CalendarResponse ExecuteCalendarCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new CalendarResponse(connector.ExecuteCommand(CreateCalendarCommand(prettyPrint)).ToString());
        }

        public static ChartLastResponse ExecuteChartLastCommand(
          SyncAPIConnector connector,
          ChartLastInfoRecord info,
          bool prettyPrint = false)
        {
            return new ChartLastResponse(connector.ExecuteCommand(CreateChartLastCommand(info, prettyPrint)).ToString());
        }

        public static ChartLastResponse ExecuteChartLastCommand(
          SyncAPIConnector connector,
          string symbol,
          PERIOD_CODE period,
          long? start,
          bool prettyPrint = false)
        {
            return new ChartLastResponse(connector.ExecuteCommand(CreateChartLastCommand(symbol, period, start, prettyPrint)).ToString());
        }

        public static ChartRangeResponse ExecuteChartRangeCommand(
          SyncAPIConnector connector,
          ChartRangeInfoRecord info,
          bool prettyPrint = false)
        {
            return new ChartRangeResponse(connector.ExecuteCommand(CreateChartRangeCommand(info, prettyPrint)).ToString());
        }

        public static ChartRangeResponse ExecuteChartRangeCommand(
          SyncAPIConnector connector,
          string symbol,
          PERIOD_CODE period,
          long? start,
          long? end,
          long? ticks,
          bool prettyPrint = false)
        {
            return new ChartRangeResponse(connector.ExecuteCommand(CreateChartRangeCommand(symbol, period, start, end, ticks, prettyPrint)).ToString());
        }

        public static CommissionDefResponse ExecuteCommissionDefCommand(
          SyncAPIConnector connector,
          string symbol,
          double? volume,
          bool prettyPrint = false)
        {
            return new CommissionDefResponse(connector.ExecuteCommand(CreateCommissionDefCommand(symbol, volume, prettyPrint)).ToString());
        }

        public static IbsHistoryResponse ExecuteIbsHistoryCommand(
          SyncAPIConnector connector,
          long start,
          long end,
          bool prettyPrint = false)
        {
            return new IbsHistoryResponse(connector.ExecuteCommand(CreateGetIbsHistoryCommand(start, end, prettyPrint)).ToString());
        }

        [Obsolete("Up from 2.3.3 login is not a long, but string")]
        public static LoginResponse ExecuteLoginCommand(
          SyncAPIConnector connector,
          long userId,
          string password,
          bool prettyPrint = false)
        {
            return ExecuteLoginCommand(connector, userId.ToString(), password, prettyPrint);
        }

        public static LoginResponse ExecuteLoginCommand(
          SyncAPIConnector connector,
          string userId,
          string password,
          bool prettyPrint = false)
        {
            Credentials credentials = new(userId, password);
            return ExecuteLoginCommand(connector, credentials, prettyPrint);
        }

        public static LoginResponse ExecuteLoginCommand(
          SyncAPIConnector connector,
          Credentials credentials,
          bool prettyPrint = false)
        {
            LoginCommand loginCommand = CreateLoginCommand(credentials, prettyPrint);
            LoginResponse loginResponse = new LoginResponse(connector.ExecuteCommand(loginCommand).ToString());
            redirectCounter = 0;

            for (; loginResponse.RedirectRecord != null; loginResponse = new LoginResponse(connector.ExecuteCommand(loginCommand).ToString()))
            {
                if (redirectCounter >= 3)
                    throw new APICommunicationException("too many redirects");
                Server server = new Server(
                    loginResponse.RedirectRecord.Address, 
                    loginResponse.RedirectRecord.MainPort, 
                    loginResponse.RedirectRecord.StreamingPort, 
                    true, "Redirected to: " + loginResponse.RedirectRecord.Address  
                    + ":" + loginResponse.RedirectRecord.MainPort 
                    + "/" + loginResponse.RedirectRecord.StreamingPort);
                
                connector.Redirect(server);
                ++redirectCounter;
            }
            if (loginResponse.StreamSessionId != null)
                connector.Streaming.StreamSessionId = loginResponse.StreamSessionId;
            return loginResponse;
        }

        public static LogoutResponse ExecuteLogoutCommand(SyncAPIConnector connector)
        {
            return new LogoutResponse(connector.ExecuteCommand(CreateLogoutCommand()).ToString());
        }

        public static MarginLevelResponse ExecuteMarginLevelCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new MarginLevelResponse(connector.ExecuteCommand(CreateMarginLevelCommand(prettyPrint)).ToString());
        }

        public static MarginTradeResponse ExecuteMarginTradeCommand(
          SyncAPIConnector connector,
          string symbol,
          double? volume,
          bool prettyPrint)
        {
            return new MarginTradeResponse(connector.ExecuteCommand(CreateMarginTradeCommand(symbol, volume, prettyPrint)).ToString());
        }

        public static NewsResponse ExecuteNewsCommand(
          SyncAPIConnector connector,
          long? start,
          long? end,
          bool prettyPrint = false)
        {
            return new NewsResponse(connector.ExecuteCommand(CreateNewsCommand(start, end, prettyPrint)).ToString());
        }

        public static ServerTimeResponse ExecuteServerTimeCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new ServerTimeResponse(connector.ExecuteCommand(CreateServerTimeCommand(prettyPrint)).ToString());
        }

        public static CurrentUserDataResponse ExecuteCurrentUserDataCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new CurrentUserDataResponse(connector.ExecuteCommand(CreateCurrentUserDataCommand(prettyPrint)).ToString());
        }

        public static PingResponse ExecutePingCommand(SyncAPIConnector connector, bool prettyPrint = false)
        {
            return new PingResponse(connector.ExecuteCommand(CreatePingCommand(prettyPrint)).ToString());
        }

        public static ProfitCalculationResponse ExecuteProfitCalculationCommand(
          SyncAPIConnector connector,
          string symbol,
          double? volume,
          TRADE_OPERATION_CODE cmd,
          double? openPrice,
          double? closePrice,
          bool prettyPrint = false)
        {
            return new ProfitCalculationResponse(connector.ExecuteCommand(CreateProfitCalculationCommand(symbol, volume, cmd, openPrice, closePrice, prettyPrint)).ToString());
        }

        [Obsolete("Command not available in API any more")]
        public static AllSymbolGroupsResponse ExecuteSymbolGroupsCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return null;
        }

        public static StepRulesResponse ExecuteStepRulesCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new StepRulesResponse(connector.ExecuteCommand(CreateStepRulesCommand(prettyPrint)).ToString());
        }

        public static SymbolResponse ExecuteSymbolCommand(
          SyncAPIConnector connector,
          string symbol,
          bool prettyPrint = false)
        {
            return new SymbolResponse(connector.ExecuteCommand(CreateSymbolCommand(symbol, prettyPrint)).ToString());
        }

        public static TickPricesResponse ExecuteTickPricesCommand(
          SyncAPIConnector connector,
          List<string> symbols,
          long? timestamp,
          bool prettyPrint = false)
        {
            return new TickPricesResponse(connector.ExecuteCommand(CreateTickPricesCommand(symbols, timestamp, prettyPrint)).ToString());
        }

        public static TradeRecordsResponse ExecuteTradeRecordsCommand(
          SyncAPIConnector connector,
          LinkedList<long?> orders,
          bool prettyPrint = false)
        {
            return new TradeRecordsResponse(connector.ExecuteCommand(CreateTradeRecordsCommand(orders, prettyPrint)).ToString());
        }

        public static TradeTransactionResponse ExecuteTradeTransactionCommand(
          SyncAPIConnector connector,
          TradeTransInfoRecord tradeTransInfo,
          bool prettyPrint = false)
        {
            return new TradeTransactionResponse(connector.ExecuteCommand(CreateTradeTransactionCommand(tradeTransInfo, prettyPrint)).ToString());
        }

        public static TradeTransactionResponse ExecuteTradeTransactionCommand(
          SyncAPIConnector connector,
          TRADE_OPERATION_CODE cmd,
          TRADE_TRANSACTION_TYPE type,
          double? price,
          double? sl,
          double? tp,
          string symbol,
          double? volume,
          long? order,
          string customComment,
          long? expiration,
          bool prettyPrint = false)
        {
            return new TradeTransactionResponse(connector.ExecuteCommand(CreateTradeTransactionCommand(cmd, type, price, sl, tp, symbol, volume, order, customComment, expiration, prettyPrint)).ToString());
        }

        [Obsolete("Method outdated. ie_deviation is not available any more")]
        public static TradeTransactionResponse ExecuteTradeTransactionCommand(
          SyncAPIConnector connector,
          TRADE_OPERATION_CODE cmd,
          TRADE_TRANSACTION_TYPE type,
          double? price,
          double? sl,
          double? tp,
          string symbol,
          double? volume,
          long? ie_deviation,
          long? order,
          string comment,
          long? expiration,
          bool prettyPrint = false)
        {
            return new TradeTransactionResponse(connector.ExecuteCommand(CreateTradeTransactionCommand(cmd, type, price, sl, tp, symbol, volume, order, "", expiration, prettyPrint)).ToString());
        }

        public static TradeTransactionStatusResponse ExecuteTradeTransactionStatusCommand(
          SyncAPIConnector connector,
          long? order,
          bool prettyPrint = false)
        {
            return new TradeTransactionStatusResponse(connector.ExecuteCommand(CreateTradeTransactionStatusCommand(order, prettyPrint)).ToString());
        }

        public static TradesResponse ExecuteTradesCommand(
          SyncAPIConnector connector,
          bool openedOnly,
          bool prettyPrint = false)
        {
            return new TradesResponse(connector.ExecuteCommand(CreateTradesCommand(openedOnly, prettyPrint)).ToString());
        }

        public static TradesHistoryResponse ExecuteTradesHistoryCommand(
          SyncAPIConnector connector,
          long? start,
          long? end,
          bool prettyPrint = false)
        {
            return new TradesHistoryResponse(connector.ExecuteCommand(CreateTradesHistoryCommand(start, end, prettyPrint)).ToString());
        }

        public static TradingHoursResponse ExecuteTradingHoursCommand(
          SyncAPIConnector connector,
          List<string> symbols,
          bool prettyPrint = false)
        {
            return new TradingHoursResponse(connector.ExecuteCommand(CreateTradingHoursCommand(symbols, prettyPrint)).ToString());
        }

        public static VersionResponse ExecuteVersionCommand(
          SyncAPIConnector connector,
          bool prettyPrint = false)
        {
            return new VersionResponse(connector.ExecuteCommand(CreateVersionCommand(prettyPrint)).ToString());
        }
    }
}
