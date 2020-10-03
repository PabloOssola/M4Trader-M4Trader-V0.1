using System;

namespace M4Trader.ordenes.server.MCContext.Entidades.Attributes
{
    /// <summary>
    ///     Allows skipping of tracking of columns.
    ///     Place this attributer on the entity property which you dont wish to track for audit.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SkipTrackingAttribute : Attribute
    {

    }
}