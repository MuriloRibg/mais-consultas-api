using System;

public class Professional
{
	public int Id { get; protected set; }
	public string Name { get; protected set; }
	public string Service { get; protected set; }
	public string Provider { get; protected set; }

	public Professional(string name, Service service, Provider provider)
	{
		SetName(name);
		SetService(service);
		SetProvider(provider);
	}

	public void SetName(string name) 
	{
		if (string.IsNullOrEmpty(name)) 
			throw new ArgumentNullException("Name");

		Name = name;
	}

	public void SetService(Service service)
	{
		Service = service;
	}

	public void SetProvider(Provider provider)
	{
		Provider = provider;
	}
}
