using System;
using Serilog.Core;

namespace Quantum.Logging.Adapter;

public interface ILoggerAdapter
{
    private static readonly object[] NoPropertyValues = Array.Empty<object>();
    

    #region Verbose

    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose(string messageTemplate) => this.Write(LogEventLevel.Verbose, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose<T>(string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Verbose, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1) => this.Write<T0, T1>(LogEventLevel.Verbose, messageTemplate, propertyValue0, propertyValue1);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose<T0, T1, T2>(
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Verbose, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose(string messageTemplate, params object?[]? propertyValues) => this.Verbose((Exception)null, messageTemplate, propertyValues);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose(Exception? exception, string messageTemplate) => this.Write(LogEventLevel.Verbose, exception, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose<T>(Exception? exception, string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Verbose, exception, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose<T0, T1>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1)
    {
        this.Write<T0, T1>(LogEventLevel.Verbose, exception, messageTemplate, propertyValue0, propertyValue1);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose<T0, T1, T2>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Verbose, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Verbose(Exception? exception, string messageTemplate, params object?[]? propertyValues) => this.Write(LogEventLevel.Verbose, exception, messageTemplate, propertyValues);
        

    #endregion

    #region Debug

    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug(string messageTemplate) => this.Write(LogEventLevel.Debug, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug<T>(string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Debug, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1) => this.Write<T0, T1>(LogEventLevel.Debug, messageTemplate, propertyValue0, propertyValue1);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug<T0, T1, T2>(
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Debug, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug(string messageTemplate, params object?[]? propertyValues) => this.Debug((Exception)null, messageTemplate, propertyValues);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug(Exception? exception, string messageTemplate) => this.Write(LogEventLevel.Debug, exception, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug<T>(Exception? exception, string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Debug, exception, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug<T0, T1>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1)
    {
        this.Write<T0, T1>(LogEventLevel.Debug, exception, messageTemplate, propertyValue0, propertyValue1);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug<T0, T1, T2>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Debug, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Debug(Exception? exception, string messageTemplate, params object?[]? propertyValues) => this.Write(LogEventLevel.Debug, exception, messageTemplate, propertyValues);

        

    #endregion

    #region Information

    [MessageTemplateFormatMethod("messageTemplate")]
    void Information(string messageTemplate) => this.Write(LogEventLevel.Information, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information<T>(string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Information, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1) => this.Write<T0, T1>(LogEventLevel.Information, messageTemplate, propertyValue0, propertyValue1);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1, T2>(
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Information, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information(string messageTemplate, params object?[]? propertyValues) => this.Information((Exception)null, messageTemplate, propertyValues);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information(Exception? exception, string messageTemplate) => this.Write(LogEventLevel.Information, exception, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information<T>(Exception? exception, string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Information, exception, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1)
    {
        this.Write<T0, T1>(LogEventLevel.Information, exception, messageTemplate, propertyValue0, propertyValue1);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information<T0, T1, T2>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Information, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Information(Exception? exception, string messageTemplate, params object?[]? propertyValues) => this.Write(LogEventLevel.Information, exception, messageTemplate, propertyValues);
        

    #endregion

    #region Warning

    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning(string messageTemplate) => this.Write(LogEventLevel.Warning, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T>(string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Warning, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1) => this.Write<T0, T1>(LogEventLevel.Warning, messageTemplate, propertyValue0, propertyValue1);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1, T2>(
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Warning, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning(string messageTemplate, params object?[]? propertyValues) => this.Warning((Exception)null, messageTemplate, propertyValues);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning(Exception? exception, string messageTemplate) => this.Write(LogEventLevel.Warning, exception, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T>(Exception? exception, string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Warning, exception, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1)
    {
        this.Write<T0, T1>(LogEventLevel.Warning, exception, messageTemplate, propertyValue0, propertyValue1);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning<T0, T1, T2>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Warning, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Warning(Exception? exception, string messageTemplate, params object?[]? propertyValues) => this.Write(LogEventLevel.Warning, exception, messageTemplate, propertyValues);

    #endregion

    #region Error


    [MessageTemplateFormatMethod("messageTemplate")]
    void Error(string messageTemplate) => this.Write(LogEventLevel.Error, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error<T>(string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Error, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1) => this.Write<T0, T1>(LogEventLevel.Error, messageTemplate, propertyValue0, propertyValue1);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1, T2>(
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Error, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error(string messageTemplate, params object?[]? propertyValues) => this.Error((Exception)null, messageTemplate, propertyValues);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error(Exception? exception, string messageTemplate) => this.Write(LogEventLevel.Error, exception, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error<T>(Exception? exception, string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Error, exception, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1)
    {
        this.Write<T0, T1>(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1);
    }


    [MessageTemplateFormatMethod("messageTemplate")]
    void Error<T0, T1, T2>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

   
    [MessageTemplateFormatMethod("messageTemplate")]
    void Error(Exception? exception, string messageTemplate, params object?[]? propertyValues) => this.Write(LogEventLevel.Error, exception, messageTemplate, propertyValues);
        

    #endregion

    #region Fatal

    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(string messageTemplate) => this.Write(LogEventLevel.Fatal, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T>(string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Fatal, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1) => this.Write<T0, T1>(LogEventLevel.Fatal, messageTemplate, propertyValue0, propertyValue1);

   
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1, T2>(
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Fatal, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(Exception? exception, string messageTemplate) => this.Write(LogEventLevel.Fatal, exception, messageTemplate);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T>(Exception? exception, string messageTemplate, T propertyValue) => this.Write<T>(LogEventLevel.Fatal, exception, messageTemplate, propertyValue);
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1)
    {
        this.Write<T0, T1>(LogEventLevel.Fatal, exception, messageTemplate, propertyValue0, propertyValue1);
    }
    
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal<T0, T1, T2>(
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2)
    {
        this.Write<T0, T1, T2>(LogEventLevel.Fatal, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

  
    [MessageTemplateFormatMethod("messageTemplate")]
    void Fatal(Exception? exception, string messageTemplate, params object?[]? propertyValues) 
        => this.Write(LogEventLevel.Fatal, exception, messageTemplate, propertyValues);
        

    #endregion







    /// <summary>Write a log event with the specified level.</summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write(LogEventLevel level, string messageTemplate);

    /// <summary>Write a log event with the specified level.</summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write<T>(LogEventLevel level, string messageTemplate, T propertyValue);

    /// <summary>Write a log event with the specified level.</summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1>(
        LogEventLevel level,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1);

    /// <summary>Write a log event with the specified level.</summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1, T2>(
        LogEventLevel level,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2);


    /// <summary>
    /// Write a log event with the specified level and associated exception.
    /// </summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write(LogEventLevel level, Exception? exception, string messageTemplate);

    /// <summary>
    /// Write a log event with the specified level and associated exception.
    /// </summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue">Object positionally formatted into the message template.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write<T>(
        LogEventLevel level,
        Exception? exception,
        string messageTemplate,
        T propertyValue);

    /// <summary>
    /// Write a log event with the specified level and associated exception.
    /// </summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1>(
        LogEventLevel level,
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1);

    /// <summary>
    /// Write a log event with the specified level and associated exception.
    /// </summary>
    /// <param name="level">The level of the event.</param>
    /// <param name="exception">Exception related to the event.</param>
    /// <param name="messageTemplate">Message template describing the event.</param>
    /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
    /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
    [MessageTemplateFormatMethod("messageTemplate")]
    void Write<T0, T1, T2>(
        LogEventLevel level,
        Exception? exception,
        string messageTemplate,
        T0 propertyValue0,
        T1 propertyValue1,
        T2 propertyValue2);
    
    
}