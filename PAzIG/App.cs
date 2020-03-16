using MvvmCross;
using PAzIG.Services;

namespace PAzIG
{
    public class App : MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterSingleton<IProductManager>(new MockProductManager());

            RegisterAppStart<ViewModel.MainViewModel>();
        }
    }
}
