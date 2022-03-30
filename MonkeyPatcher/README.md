# MonkeyPatch

MonkeyPatch leverages the power of MonoMod and Castle.Core to override Concrete, Abstract and Interface types (including private and static methods).

## What's new

Removed a bug that caused the patcher not to find methods.
Added overloads for all the `Override` methods to support plain results rather than only actions.

## The Api

For concrete instance or static types, your code would look something like this:

![BasicUsage](https://user-images.githubusercontent.com/81313844/156667297-bbdf551a-29b1-4713-b3c2-ddb3fd520368.jpg)

While for interfaces, abstract and virtual types:

![BasicUsage](https://user-images.githubusercontent.com/81313844/156667468-238dcc40-9a6a-4e0e-a58d-f3e2db7e37b3.jpg)

The two apis look very similar, but under the hood they are very different. The goal is to have a very simple api (just a handful of options) that writes the new method body for the desired target.
