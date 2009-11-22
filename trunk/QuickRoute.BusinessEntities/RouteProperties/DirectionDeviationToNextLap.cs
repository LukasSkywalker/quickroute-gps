using System;
using QuickRoute.BusinessEntities.Numeric;

namespace QuickRoute.BusinessEntities.RouteProperties
{
  public class DirectionDeviationToNextLap : RouteMomentaneousProperty
  {
    public DirectionDeviationToNextLap(Session session, RouteLocations locations)
      : base(session, locations)
    {
    }

    public DirectionDeviationToNextLap(Session session, ParameterizedLocation location)
      : base(session, location)
    {
    }

    protected override void Calculate()
    {
      var cachedProperty = GetFromCache();
      if (cachedProperty != null)
      {
        value = cachedProperty.Value;
        return;
      }
      value = Session.Route.GetAttributeFromParameterizedLocation(WaypointAttribute.DirectionDeviationToNextLap, Location);
      AddToCache();
    }

    public override int CompareTo(object obj)
    {
      return (Convert.ToDouble(Value)).CompareTo(Convert.ToDouble(((RouteProperty)obj).Value));
    }

    protected override string ValueToString(object v, string format, IFormatProvider provider)
    {
      if (format == null) format = "{0:n0}";
      return string.Format(provider, format, Convert.ToDouble(v));
    }

    public override string MaxWidthString
    {
      get { return ValueToString((double?)999); }
    }

    public override bool ContainsValue
    {
      get { return true; }
    }
  }
}