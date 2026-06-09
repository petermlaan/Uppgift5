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
    public void RemoveVehicle(T vehicle)
    {
        for (int i = 0; i < _vehicles.Length; i++)
            if (_vehicles[i] != null && _vehicles[i]!.License.ToUpper() == vehicle.License.ToUpper())
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
    public IEnumerable<T> Search(string license, string color)
    {
        return this.Where(v => 
            (license.Length == 0 || license.ToUpper() == v.License.ToUpper()) 
            && (color.Length == 0 || color.ToUpper() == v.Color.ToUpper()));

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
