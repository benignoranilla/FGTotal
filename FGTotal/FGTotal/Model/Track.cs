using System;
using System.Collections.Generic;
using System.Text;

namespace FGTotal.Model
{
	public class Track
	{
		public string orderId { get; set; }
		public string price { get; set; }
		public string status { get; set; }
		public int numberofItems { get; set; }
		public override string ToString()
		{
			return orderId;
		}
	}


}
