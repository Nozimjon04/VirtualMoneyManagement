﻿using System.Text.RegularExpressions;

namespace UserWebApi.Helpers
{
	public class RouteConfiguration : IOutboundParameterTransformer
	{
		public string TransformOutbound(object value)
		{
			return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
		}
	}
}
