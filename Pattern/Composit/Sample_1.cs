public class IComposit{
	void Entry(IComposit entry);
}

public class Folder{
	List<IComposit> entries = new List<IComposit>();

	void Entry(IComposit entry){
		entries.Add(entry);
	}
}
