# LeagueSharp.Data

LeagueSharp.Data is an SDK with APIs to easily retrieve League of Legends related data. Currently it supports:

* Champion Priorties
* Damages
* Flash Juke Locations
* Gapclosers
* Interruptable Spells
* Map information
* Spell Database
* Trap Locations
* Champion data
* Item data

# Usage

All of the data can be accessed via the [`Data`](https://github.com/LeagueSharp/LeagueSharp.Data/blob/master/LeagueSharp.Data/Data.cs) class.

```csharp
Data.Get<T>();
```

For instance, to retrieve spell data, simply get the [`SpellDatabase`](https://github.com/LeagueSharp/LeagueSharp.Data/blob/master/LeagueSharp.Data/DataTypes/SpellDatabase.cs) class.

```csharp
Data.Get<SpellDatabase>();
```

From there, you can use the methods of the [`SpellDatabase`](https://github.com/LeagueSharp/LeagueSharp.Data/blob/master/LeagueSharp.Data/DataTypes/SpellDatabase.cs) class to retrieve spell data.
For a complete list of data types that are retrievable, see the [`LeagueSharp.Data.DataTypes`](https://github.com/LeagueSharp/LeagueSharp.Data/tree/master/LeagueSharp.Data/DataTypes) namespace.
