using System.ComponentModel.DataAnnotations;

public class Professional
{
	[Key]
	[Required]
	public int Id { get; set; }

	[Required]
	[StringLength(100)]
	public string Name { get; set; }

	[Required]
	public string Service { get; set; }

	[Required]
	public string Provider { get; set; }

	public Professional(string name, string service, string provider)
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

	public void SetService(string service)
	{
		Service = service;
	}

	public void SetProvider(string provider)
	{
		Provider = provider;
	}
}
