﻿using System;
using System.Collections.Generic;
using System.Text;
sealed class Disposable : IDisposable
{
    private Action Action;
    private bool disposedValue;
    private Disposable(Action Action)
        => this.Action = Action;
    public static IDisposable Create(Action Action) => new Disposable(Action);

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Action();
            }
            disposedValue = true;
        }
    }
    ~Disposable()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
