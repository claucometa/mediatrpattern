namespace ConsoleApp1
{
    public class BaseCommand
    {
        public ItemVm Item;

        public BaseCommand(ItemVm item)
        {
            this.Item = item;
        }
    }
}