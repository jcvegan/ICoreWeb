// Jcvegan.com - Juan Vega
// ICoreWeb.Data.Identity.Service.Initializer 2019
// LoggingFact.cs
// Todos los derechos reservados

using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ICoreWeb.Data.Identity.Service.Initializer.Logging
{
    public class LoggingFact : IInterceptor
    {
        private readonly ILogger _logger;

        public LoggingFact(ILogger<LoggingFact> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();
            var method = invocation.Method.Name;
            try
            {
                _logger.LogInformation($"Start Invocation of {method} on class {invocation.TargetType.FullName}.");

                LogParameters(invocation);

                invocation.Proceed();

                LogResult(invocation);
            }
            catch (Exception exc)
            {
                _logger.LogError(default(EventId), exc, exc.Message);
            }
            finally
            {
                watch.Stop();
                _logger.LogInformation(
                    $"The method {method} in {invocation.TargetType.FullName} executed on {watch.ElapsedMilliseconds} ms.");
                _logger.LogInformation($"End Invocation of {method} on class {invocation.TargetType.FullName}");
            }
        }

        private void LogParameters(IInvocation invocation)
        {
            var method = invocation.Method.Name;
            var arguments = invocation.Arguments;
            for (int i = 0; i < arguments.Length; i++)
            {
                var parameter = arguments[i];
                if (parameter != null)
                    _logger.LogInformation(
                        $"Invocation of {method} pass parameter {i + 1} of type {parameter.GetType()} with value: {FormatType(parameter.GetType(), parameter)}");
                else
                    _logger.LogInformation($"Invocation of {method} pass parameter {i + 1} with value: null");
            }
        }

        private void LogResult(IInvocation invocation)
        {
            var method = invocation.Method.Name;

            var returnType = invocation.Method.ReturnType;

            _logger.LogInformation($"Invocation of {method} returns {FormatType(returnType, invocation.ReturnValue)}");
        }

        private string FormatType(Type resultType, object returnedValue)
        {
            if (returnedValue == null)
                return "null";

            if (resultType == typeof(DateTime))
                return Convert.ToDateTime(returnedValue).ToString("yyyy-MM-dd HH:mm:ss");

            if (resultType == typeof(object))
                return JsonConvert.SerializeObject(returnedValue);

            return returnedValue.ToString();
        }
    }
}