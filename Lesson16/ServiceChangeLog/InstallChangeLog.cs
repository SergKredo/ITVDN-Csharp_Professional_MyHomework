using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;


namespace ServiceChangeLog
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        ServiceProcessInstaller processInstaller;
        ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {

            // Оснавная информация о свойствах NT-службы
            processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller = new ServiceInstaller();
            serviceInstaller.ServiceName = "[==== ServiceChangeLogDisks ====]";
            serviceInstaller.Description = "My NT (Windows) Service!";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            base.Installers.Add(processInstaller);
            base.Installers.Add(serviceInstaller);
        }
    }
}
