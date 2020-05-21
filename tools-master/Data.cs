using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Tools
{
    public class Data<T> where T : struct
    {
        private Type _type;
        private int _size;

        private int _max;
        private int _offset;
        private int _ptr;

        public Data()
        {
            _type = typeof(T);
            _size = Marshal.SizeOf(_type);
            Exe((rw, data) => data._offset = rw.ReadPointer(data._ptr));
        }

        public T GetOne(int index)
        {
            var rw = new ReadAndWrite();
            var data = rw.ReadBytes(_offset, index, _size);
            return (T) StructsUtil.ByteToStruct(data, typeof(T));
        }

        private delegate void Execute(ReadAndWrite rw, Data<T> data);

        private void Exe(Execute exe)
        {
            using var rw = new ReadAndWrite();
            exe(rw, this);
        }
    }
}