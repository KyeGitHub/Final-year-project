public interface IItemContainer
{
    int ItemCount(Item item);
    bool ContainsItem(Item item);
    bool Remove(Item item);
    bool Add(Item item, int amount);
    bool IsFull();

}
