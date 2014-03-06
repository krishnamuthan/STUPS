﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
	using System.Linq;

	/// <summary>
	/// Description of TablePatternAdapterNet.
	/// </summary>
	public class UiaTablePattern : ITablePattern
	{
		private classic.TablePattern _tablePattern;
		private IUiElement _element;

		public UiaTablePattern(IUiElement element, classic.TablePattern tablePattern)
		{
			this._tablePattern = tablePattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public UiaTablePattern(IUiElement element)
		{
			this._element = element;
		}

		public struct TablePatternInformation : ITablePatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly ITablePattern _tablePattern;

			public TablePatternInformation(ITablePattern tablePattern, bool useCache)
			{
				this._tablePattern = tablePattern;
				this._useCache = useCache;
			}
			
			public int RowCount {
				// get { return (int)this._el.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
				get { return (int)this._tablePattern.GetParentElement().GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
			}
			public int ColumnCount {
				// get { return (int)this._el.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
				get { return (int)this._tablePattern.GetParentElement().GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
			}
			public classic.RowOrColumnMajor RowOrColumnMajor {
				// get { return (RowOrColumnMajor)this._el.GetPatternPropertyValue(TablePattern.RowOrColumnMajorProperty, this._useCache); }
				get { return (RowOrColumnMajor)this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowOrColumnMajorProperty, this._useCache); }
			}
//			internal TablePatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
			
			public IUiElement[] GetRowHeaders()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
                // 20140302
				// AutomationElement[] nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
                var nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
				if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
				    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
				}
			}
			
			public IUiElement[] GetColumnHeaders()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
                // 20140302
                // AutomationElement[] nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
                var nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
				IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
                if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
                    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
				}
			}
		}
		public static readonly classic.AutomationPattern Pattern = TablePatternIdentifiers.Pattern;
        /*
        public static new readonly AutomationPattern Pattern = TablePatternIdentifiers.Pattern;
        */
        public static readonly classic.AutomationProperty RowHeadersProperty = TablePatternIdentifiers.RowHeadersProperty;
		public static readonly classic.AutomationProperty ColumnHeadersProperty = TablePatternIdentifiers.ColumnHeadersProperty;
		public static readonly classic.AutomationProperty RowOrColumnMajorProperty = TablePatternIdentifiers.RowOrColumnMajorProperty;
		
		public virtual ITablePatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new TablePattern.TablePatternInformation(this._el, true);
				return new UiaTablePattern.TablePatternInformation(this, true);
			}
		}
		
		public virtual ITablePatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new TablePattern.TablePatternInformation(this._el, false);
				return new UiaTablePattern.TablePatternInformation(this, false);
			}
		}
//		private UiaTablePattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern, cached)
//		{
//		}
//		static internal new object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new TablePattern(el, hPattern, cached);
//		}
		
		public void SetParentElement(IUiElement element)
		{
		    this._element = element;
		}
		
		public IUiElement GetParentElement()
		{
		    return this._element;
		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._tablePattern = pattern as TablePattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._tablePattern;
		}
	}
}
