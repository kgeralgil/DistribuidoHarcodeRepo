using Genesyslab.Desktop.Infrastructure;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;

namespace WpfApplication3
{
	/// <summary>
	/// Interface matching the MySampleView view
	/// </summary>
	public interface InterfazGUI : IView,IMin
	{
		interfaceModeloPresentacionGUI Model { get; set; }
	}
}
