using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SQLOperator.Options;
using SQLOperator.Services;
using Task = System.Threading.Tasks.Task;

namespace SQLOperator
{
	///
	/// SQLOperator © 2025 by Sean Gallardy is licensed under CC BY-NC-ND 4.0 
	///

	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[Guid(SQLOperatorPackage.PackageGuidString)]
	[ProvideOptionPage(typeof(OperatorGeneralOptionsPage), "SQLOperator", "General", 0, 0, true)]
	//This is the GUID for object explorer taken from the registry
	[ProvideAutoLoad("d114938f-591c-46cf-a785-500a82d97410", PackageAutoLoadFlags.BackgroundLoad)]
	public sealed class SQLOperatorPackage : AsyncPackage
	{
		/// <summary>
		/// SQLOperatorPackage GUID string.
		/// </summary>
		public const string PackageGuidString = "9b44f3c8-781e-4001-be02-99e953fad610";

		#region Package Members

		/// <summary>
		/// Initialization of the package; this method is called right after the package is sited, so this is the place
		/// where you can put all the initialization code that rely on services provided by VisualStudio.
		/// </summary>
		/// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
		/// <param name="progress">A provider for progress updates.</param>
		/// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			// When initialized asynchronously, the current thread may be a background thread at this point.
			// Do any initialization that requires the UI thread after switching to the UI thread.
			await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

			ServiceManager sm = new ServiceManager();

			OptionsManager optionsManager = new OptionsManager();
			optionsManager.Initialize(this);
			
			sm.RegisterService<IOptionsService>(optionsManager);
		}

		#endregion
	}
}
