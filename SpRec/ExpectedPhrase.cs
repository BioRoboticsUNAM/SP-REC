using System;
using System.Collections.Generic;
using System.Threading;

namespace SpRec
{
	public class ExpectedPhrase: IComparable, IComparable<ExpectedPhrase>, IComparable<string>
	{
		#region Variables
		
		private string phrase;
		private Timer timer;
		private int timerId;

		#endregion

		#region Constructors

		public ExpectedPhrase(string phrase, Timer timer, int timerId)
		{

			if ((phrase == null) || (phrase.Trim().Length < 1))
				throw new ArgumentNullException();
			if(timer == null)
				throw new ArgumentNullException();
			if (timerId < 0)
				throw new ArgumentException();
			this.phrase = phrase.Trim().ToLower();
			this.timer = timer;
			this.timerId = timerId;
		}

		#endregion

		#region Properties

		public string Phrase
		{
			get { return this.phrase; }
		}

		public Timer Timer
		{
			get { return this.timer; }
		}

		public int TimerId
		{
			get { return this.timerId; }
		}

		#endregion

		#region Events
		#endregion

		#region Methods
		#endregion

		#region Interface inherited

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (obj is string)
				return CompareTo((string)obj);
			if (obj is Timer)
				return CompareTo((Timer)obj);
			if (obj is ExpectedPhrase)
				return CompareTo((ExpectedPhrase)obj);
			return base.GetHashCode() - obj.GetHashCode();
		}

		#endregion

		#region IComparable<ExpectedPhrase> Members

		public int CompareTo(ExpectedPhrase other)
		{
			unchecked
			{
				return this.phrase.CompareTo(other);
			}
		}

		#endregion

		#region IComparable<string> Members

		public int CompareTo(string other)
		{
			return this.phrase.CompareTo(other);
		}

		#endregion

		#endregion
	}
}
