using MvvmCross.Base;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using System;
using System.Collections.Generic;

namespace TrueNewsFeeder.UnitTest.ViewModels
{
    public class MockDispatcher : MvxMainThreadDispatcher, IMvxViewDispatcher
    {
        public readonly List<MvxViewModelRequest> Request = new List<MvxViewModelRequest>();
        public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

        public override bool IsOnMainThread => true;

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return true;
        }

        public override bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            Request.Add(request);
            return true;
        }
    }
}
