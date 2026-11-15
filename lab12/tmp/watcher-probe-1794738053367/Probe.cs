using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

internal static class Probe
{
    [STAThread]
    private static void Main(string[] args)
    {
        var root = Path.GetFullPath(args[0]);
        Test(root, "original", (path, dispatcher) => new lab12.FileDirectoryCollection(path, dispatcher));
        Test(root, "fixed", (path, dispatcher) => new lab12fixed.FileDirectoryCollection(path, dispatcher));
    }

    private static void Test(string root, string label, Func<string, Dispatcher, ICollection> create)
    {
        string folder = Path.Combine(root, label);
        Directory.CreateDirectory(folder);
        string outside = Path.Combine(root, label + "-outside");
        Directory.CreateDirectory(outside);
        Create(Path.Combine(folder, "seed.txt"));
        var source = create(folder, Dispatcher.CurrentDispatcher);
        int events = 0;
        ((INotifyCollectionChanged)source).CollectionChanged += (_, _) => events++;
        var grid = new DataGrid { IsReadOnly = true, AutoGenerateColumns = true, DataContext = source };
        grid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("."));
        Console.WriteLine(label + " initial rows: " + grid.Items.Count);

        Create(Path.Combine(folder, "created.txt"));
        bool created = PumpUntil(() => grid.Items.Count == 2);
        File.Move(Path.Combine(folder, "created.txt"), Path.Combine(outside, "moved.txt"));
        bool deleted = PumpUntil(() => grid.Items.Count == 1);

        File.Move(Path.Combine(folder, "seed.txt"), Path.Combine(folder, "renamed.txt"));
        bool renamed = PumpUntil(() => grid.Items.Cast<FileInfo>().Any(f => f.Name == "renamed.txt"));
        Console.WriteLine($"{label}: created={created}, removed={deleted}, renamed={renamed}, notifications={events}");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        int before = events;
        Create(Path.Combine(folder, "after-gc.txt"));
        bool afterGc = PumpUntil(() => grid.Items.Count == 2 && events > before);
        Console.WriteLine($"{label}: created after GC={afterGc}, notifications={events}");
        GC.KeepAlive(source);
        GC.KeepAlive(grid);
    }

    private static void Create(string path)
    {
        using var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
        stream.WriteByte(1);
    }

    private static bool PumpUntil(Func<bool> condition)
    {
        if (condition()) return true;
        var elapsed = Stopwatch.StartNew();
        var frame = new DispatcherFrame();
        var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(20) };
        timer.Tick += (_, _) =>
        {
            if (condition() || elapsed.ElapsedMilliseconds >= 1500)
            {
                timer.Stop();
                frame.Continue = false;
            }
        };
        timer.Start();
        Dispatcher.PushFrame(frame);
        return condition();
    }
}
