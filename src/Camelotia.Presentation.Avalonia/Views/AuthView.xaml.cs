using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Camelotia.Presentation.Interfaces;
using ReactiveUI;

namespace Camelotia.Presentation.Avalonia.Views
{
    public sealed class AuthView : ReactiveUserControl<IAuthViewModel>
    {
        public AuthView()
        {
            this.WhenActivated(disposables =>
            {
                var tabs = this.FindControl<Carousel>("AuthTabs");
                this.WhenAnyValue(x => x.ViewModel.SupportsDirectAuth)
                    .Where(supports => supports)
                    .Subscribe(supports => tabs.SelectedIndex = 0)
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.ViewModel.SupportsOAuth)
                    .Where(supports => supports)
                    .Subscribe(supports => tabs.SelectedIndex = 1)
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.ViewModel.SupportsHostAuth)
                    .Where(supports => supports)
                    .Subscribe(supports => tabs.SelectedIndex = 2)
                    .DisposeWith(disposables);
            });
            AvaloniaXamlLoader.Load(this);
        }
    }
}