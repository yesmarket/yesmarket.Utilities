# yesmarket.Utilities
A bunch of yesmarket infrastructural utilities that might a) extend a particular framework, or b) define a common and consistent set of interfaces for using a particular framework for increased testability (through interface abstraction). These utilities include the following:
- <b>yesmarket.DateTimes</b>: DateTime abstraction so that you can easily mock out references to DateTime.Now, DateTime.UtcNow etc. in unit tests.
- <b>yesmarket.SimpleInjectorExtensions</b>: Some extensions to the Simple-Injector IoC framework.
- <b>yesmarket.UnitsOfWork</b>: Some helper classes providing an NHibernate transaction abstraction to help with unit/integration testing of the data-access-layer.
- <b>yesmarket.AutoMapping</b>: Set of common interfaces for configuring and using the AutoMapper framework. Primarily this set of interfaces is used for consistency and adherance to DRY.

The above utilities have all been individually pushed to nuget.

I will happily accept and review pull requests. 
