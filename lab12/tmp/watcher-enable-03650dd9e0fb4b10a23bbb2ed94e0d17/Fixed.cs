using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace lab12fixed
{
    public class FileDirectoryCollection : ICollection, INotifyCollectionChanged
    {
        string _path;
        DirectoryInfo _info;

        public int Count => _info.GetFiles().Length;
        public object SyncRoot => this;
        public bool IsSynchronized => false;

        private readonly FileSystemWatcher _watcher;


        Dispatcher _dispatcher;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public FileDirectoryCollection(string path, Dispatcher dispatcher)
        {
            _path = path;
            _info = new DirectoryInfo(path);
            _dispatcher = dispatcher;

            _watcher = new FileSystemWatcher(path);
            _watcher.Created += Fsw_Created;
            _watcher.Deleted += Fsw_Deleted;
            _watcher.Renamed += Fsw_Renamed;
            _watcher.EnableRaisingEvents = true;
            
        }

        private void Fsw_Renamed(object sender, FileSystemEventArgs e)
        {
            ResetCollection();
        }

        private void Fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            ResetCollection();
        }
        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            ResetCollection();
        }

        private void ResetCollection()
        {
            _dispatcher.Invoke(() =>
            {
                if (CollectionChanged != null)
                {
                    CollectionChanged(this, new
                   NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            });
        }


        public void CopyTo(Array array, int index)
        {

        }

        public IEnumerator GetEnumerator()
        {
            return _info.GetFiles().GetEnumerator();
        }
    }
}
