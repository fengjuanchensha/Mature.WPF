﻿using Mature.Socket.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Mature.SuperSocket.Test
{
    [TestClass]
    public class GZipTest
    {
        [TestMethod]
        public void Compress()
        {
            GZip gZip = new GZip();
            string content = @"天地有正气，杂然赋流形。下则为河岳，上则为日星。於人曰浩然，沛乎塞苍冥。
                               皇路当清夷，含和吐明庭。时穷节乃见，一一垂丹青。在齐太史简，在晋董狐笔。
                               在秦张良椎，在汉苏武节。为严将军头，为嵇侍中血。为张睢阳齿，为颜常山舌。
                               或为辽东帽，清操厉冰雪。或为出师表，鬼神泣壮烈。或为渡江楫，慷慨吞胡羯。
                               或为击贼笏，逆竖头破裂。是气所磅礴，凛烈万古存。当其贯日月，生死安足论。
                               地维赖以立，天柱赖以尊。三纲实系命，道义为之根。嗟予遘阳九，隶也实不力。
                               楚囚缨其冠，传车送穷北。鼎镬甘如饴，求之不可得。阴房阗鬼火，春院闭天黑。
                               牛骥同一皂，鸡栖凤凰食。一朝蒙雾露，分作沟中瘠。如此再寒暑，百疠自辟易。
                               哀哉沮洳场，为我安乐国。岂有他缪巧，阴阳不能贼。顾此耿耿存，仰视浮云白。
                               悠悠我心悲，苍天曷有极。哲人日已远，典刑在夙昔。风檐展书读，古道照颜色。";
            Console.WriteLine($"内容长度 {content.Length}");
            var data = gZip.Compress(content, Encoding.UTF8);
            Console.WriteLine($"压缩之后长度{data.Length}");

            var data1 = gZip.Decompress(data);
            Console.WriteLine($"解压缩之后长度{data1.Length}");
            string result = Encoding.UTF8.GetString(data1);
            Console.WriteLine(result);
            Assert.AreEqual(content, result);
        }
    }
}
