// See https://aka.ms/new-console-template for more information

using System.Drawing;
using Microsoft.Extensions.DependencyInjection;
using TagCloud2;
using TagsCloudVisualization;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<SettingsTagCloud>(x =>
    new SettingsTagCloud(new Size(2300, 2300), "./../../../photos"));


serviceCollection.AddSingleton<ICloudLayouter, CircularCloudLayouter>(
    x => new CircularCloudLayouter(new Point(11)));

var loader = new FileWordLoader();
var words = loader.LoadWord("./../../../Words.txt");
Console.WriteLine(words[0].Word);

var circularCloudLayouter = new CircularCloudLayouter(new Point(1150, 1150));
using var tagImage = new CloudBitMap(2300, 2300, "./../../../photos");
using var tagCloud = new TagCloud(circularCloudLayouter, tagImage);
tagCloud.GenerateCloud(words, 50, 250);
tagCloud.Save();
Console.WriteLine("Hello, World!");