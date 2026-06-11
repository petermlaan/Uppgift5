using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

internal class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private T?[] _vehicles;

    public Garage(int size)
    {
        _vehicles = new T[size];
    }
    public void AddVehicle(T vehicle)
    {
        foreach (var v in _vehicles)
            if (v != null && v.License.ToUpper() == vehicle.License.ToUpper())
                throw new Exception("Vehicle with same license already exists");
        for (int i = 0; i < _vehicles.Length; i++)
            if (_vehicles[i] == null)
            {
                _vehicles[i] = vehicle;
                return;
            }
        throw new Exception("Out of parking space");
    }
    public void RemoveVehicle(string license)
    {
        for (int i = 0; i < _vehicles.Length; i++)
            if (_vehicles[i] != null && _vehicles[i]!.License.ToUpper() == license.ToUpper())
            {
                _vehicles[i] = null;
                return;
            }
        throw new Exception("No such vehicle");
    }
    public T? FindVehicle(string license)
    {
        foreach (var v in _vehicles)
            if (v != null && v.License.ToUpper() == license.ToUpper())
                return v!;
        return null;
    }
    public IEnumerable<T> Search(string color,string type, int wheels = -1)
    {
        return this.Where(v => 
            (color.Length == 0 || color.ToUpper() == v.Color.ToUpper())
            && (type.Length == 0 || type.ToUpper() == v.GetType().Name.ToUpper())
            && (wheels < 0 || wheels == v.Wheels));

    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _vehicles.Length; i++)
            if (_vehicles[i] != null)
                yield return _vehicles[i]!;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
