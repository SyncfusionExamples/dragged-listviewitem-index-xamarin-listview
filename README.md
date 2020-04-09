# How to retrieve the dragged item index in ViewModel command with the Prism framework in Xamarin.Forms ListView (SfListView)?

You can retrieve the drag index of [ListViewItem](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ListViewItem.html?) in ViewModel using the [Prism](https://prismlibrary.com/docs/xamarin-forms/Getting-Started.html) framework [DelegateCommand](https://prismlibrary.com/docs/commanding.html#creating-a-delegatecommand) in Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?).

You can also refer the following article.

https://www.syncfusion.com/kb/11371

**XAML**

[EventToCommandBehavior](https://help.syncfusion.com/xamarin/listview/mvvm?_ga=2.48449378.576537389.1586149449-1204678185.1570168583#event-to-command) to convert the [ItemDragging](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemDragging_EV.html?) event to a command and set ListView behavior.

``` xml
<syncfusion:SfListView x:Name="listView" Grid.Row="1" ItemSize="60" BackgroundColor="#FFE8E8EC" GroupHeaderSize="50" ItemsSource="{Binding ToDoList}" DragStartMode="OnHold,OnDragIndicator" SelectionMode="None">
 
    <syncfusion:SfListView.Behaviors>
        <local:EventToCommandBehavior EventName="ItemDragging" Command="{Binding ItemDraggingCommand}"/>
    </syncfusion:SfListView.Behaviors>
 
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <Frame HasShadow="True" BackgroundColor="White" Padding="0">
                <Frame.InputTransparent>
                    <OnPlatform x:TypeArguments="x:Boolean" Android="True" iOS="False"/>
                </Frame.InputTransparent>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="60" />
                    </Grid.ColumnDefinitions>
                    <Label x:Name="textLabel" Text="{Binding Name}" FontSize="15" TextColor="#333333" VerticalOptions="Center" HorizontalOptions="Start" Margin="5,0,0,0" />
                    <syncfusion:DragIndicatorView Grid.Column="1" ListView="{x:Reference listView}" HorizontalOptions="Center" VerticalOptions="Center">
                        <Grid Padding="10, 20, 20, 20">
                            <Image Source="DragIndicator.png" VerticalOptions="Center" HorizontalOptions="Center" />
                        </Grid>
                    </syncfusion:DragIndicatorView>
                </Grid>
            </Frame>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

**C#**

Create command for the ItemDragging event with the [ItemDraggingEventArgs](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemDraggingEventArgs.html?) parameter. You can access the item index from [NewIndex](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemDraggingEventArgs~NewIndex.html?) field of the **ItemDraggingEventArgs**.

``` c#
public class ViewModel
{
    public DelegateCommand<ItemDraggingEventArgs> ItemDraggingCommand { get; set; }
    public ViewModel()
    {
        ItemDraggingCommand = new DelegateCommand<ItemDraggingEventArgs>(OnItemDragging);
    }
         
    private void OnItemDragging(ItemDraggingEventArgs args)
    {
        if (args.Action == DragAction.Drop)
            App.Current.MainPage.DisplayAlert("Message", "ListView item index after reordering " + args.NewIndex, "Ok");
    }
}
```

**Output**

![DragAndDropIndex](https://github.com/SyncfusionExamples/dragged-listviewitem-index-xamarin-listview/blob/master/ScreenShots/DragAndDropIndex.gif)
