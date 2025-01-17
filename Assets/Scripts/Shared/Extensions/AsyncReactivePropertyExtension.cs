﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Shared;

public static class AsyncReactivePropertyExtension
{
    public static void Invoke(this IAsyncReactiveProperty<Invoker> property)
    {
        property.Value = Invoker.New();
    }

    public static void Listen(this IReadOnlyAsyncReactiveProperty<Invoker> property, Action callback, CancellationToken token)
    {
        property.WithoutCurrent().ForEachAsync(_ => callback(), token).Forget();
    }
}