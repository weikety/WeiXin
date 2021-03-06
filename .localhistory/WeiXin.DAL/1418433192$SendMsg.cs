﻿
using System.Collections.Generic;
using System.Text;
using WeiXin.Common;
using WeiXin.Model.SendMsg;

namespace WeiXin.DAL
{
    public class SendMsg
    {

        #region 回复消息的公共函数

        /// <summary>
        ///  回复的文本消息的函数
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="content">The content.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-17 14:46:20
        private static void ProduceText(Dictionary<string, string> model, string content)
        {
            SendText text = new SendText();
            text.ToUserName = model.ReadKey(PublicField.FromUserName);
            text.FromUserName = model.ReadKey(PublicField.ToUserName);
            text.CreateTime = int.Parse(model.ReadKey(PublicField.CreateTime));
            text.MsgType = "text";
            text.Content = content;
            OperateXml.ResponseEnd(Templete.SendText(text));
        }

        /// <summary>
        ///  回复的图片消息的函数
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="mediaId">服务器上图片的ID</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 10:23:10
        private static void ProduceImage(Dictionary<string, string> model, string mediaId)
        {
            SendImage image = new SendImage();
            image.ToUserName = model.ReadKey(PublicField.FromUserName);
            image.FromUserName = model.ReadKey(PublicField.ToUserName);
            image.CreateTime = int.Parse(model.ReadKey(PublicField.CreateTime));
            image.MsgType = "image";
            image.MediaId = mediaId;
            OperateXml.ResponseEnd(Templete.SendImg(image));
        }

        /// <summary>
        ///  回复的语音消息的函数
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="mediaId">服务器上语音的ID</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 10:25:01
        private static void ProduceVoice(Dictionary<string, string> model, int mediaId)
        {
            SendVoice voice = new SendVoice();
            voice.ToUserName = model.ReadKey(PublicField.FromUserName);
            voice.FromUserName = model.ReadKey(PublicField.ToUserName);
            voice.CreateTime = int.Parse(model.ReadKey(PublicField.CreateTime));
            voice.MsgType = "voice";
            voice.MediaId = mediaId;
            OperateXml.ResponseEnd(Templete.SendVoice(voice));
        }

        /// <summary>
        ///  回复的视频消息的函数
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="mediaId">服务器上视频的ID</param>
        /// <param name="title">title</param>
        /// <param name="description">描述</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 10:25:01
        private static void ProduceVideo(Dictionary<string, string> model, int mediaId, string title, string description)
        {
            SendVideo video = new SendVideo();
            video.ToUserName = model.ReadKey(PublicField.FromUserName);
            video.FromUserName = model.ReadKey(PublicField.ToUserName);
            video.CreateTime = int.Parse(model.ReadKey(PublicField.CreateTime));
            video.MsgType = "video";
            video.MediaId = mediaId;
            video.Title = title;
            video.Description = description;
            OperateXml.ResponseEnd(Templete.SendVideo(video));
        }

        /// <summary>
        ///  回复的音乐消息的函数
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="title">音乐标题</param>
        /// <param name="description">音乐描述</param>
        /// <param name="musicUrl">音乐链接</param>
        /// <param name="hqMusicUrl">高质量音乐链接，WIFI环境优先使用该链接播放音乐</param>
        /// <param name="thumbMediaId">缩略图的媒体id，通过上传多媒体文件，得到的id</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 10:25:01
        private static void ProduceMusic(Dictionary<string, string> model, string title, string description, string musicUrl, string hqMusicUrl, int thumbMediaId)
        {
            SendMusic music = new SendMusic();
            music.ToUserName = model.ReadKey(PublicField.FromUserName);
            music.FromUserName = model.ReadKey(PublicField.ToUserName);
            music.CreateTime = int.Parse(model.ReadKey(PublicField.CreateTime));
            music.MsgType = "music";
            music.Title = title;
            music.Description = description;
            music.MusicUrl = musicUrl;
            music.HqMusicUrl = hqMusicUrl;
            music.ThumbMediaId = thumbMediaId;
            OperateXml.ResponseEnd(Templete.SendMusic(music));
        }

        /// <summary>
        ///  回复的图文消息的函数
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="articles">The content.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 09:57:37
        private static void ProduceNews(Dictionary<string, string> model, List<ArticlesModel> articles)
        {
            SendPicTxt news = new SendPicTxt();
            news.ToUserName = model.ReadKey(PublicField.FromUserName);
            news.FromUserName = model.ReadKey(PublicField.ToUserName);
            news.CreateTime = int.Parse(model.ReadKey(PublicField.CreateTime));
            news.MsgType = "news";
            news.ArticleCount = articles.Count.ToString("D");
            news.Articles = articles;
            OperateXml.ResponseEnd(Templete.SendNews(news));
        }

        #endregion


        /// <summary>
        ///  回复文本消息
        /// </summary>
        /// <param name="model">The model.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-10 12:58:35
        public static void ReplyTexts(Dictionary<string, string> model)
        {
            string content = string.Format("您输入的内容1为：{0}", model.ReadKey(PublicField.Content));
            ProduceText(model, content);
        }

        /// <summary>
        ///  回复扫码推事件消息
        /// </summary>
        /// <param name="model">The model.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-13 16:01:33
        public static void ReplyScanCodePush(Dictionary<string, string> model)
        {

        }

        /// <summary>
        ///  回复扫码推事件且弹出“消息接收中”提示框消息
        /// </summary>
        /// <param name="model">The model.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-13 16:09:53
        public static void ReplyScanCodeWaitmsg(Dictionary<string, string> model)
        {
            string value = model.ReadKey("ScanCodeInfo").Substring(6);
            switch (value)
            {
                case "1":
                    string content = string.Format("项目编号：{0};\n验收状态：{1};\n验收结果：{2};\n报表查看：<a href='{3}'>点击查看</a>", value, "完成", "通过", "http://www.sxajj.gov.cn/1.jpg");
                    ProduceText(model, content);
                    break;
                case "2":
                    List<ArticlesModel> articles = new List<ArticlesModel>();
                    ArticlesModel article = new ArticlesModel();
                    article.Title = string.Format("一号项目\n项目编号：CX2501;验收状态:完成;验收结果:通过;");
                    article.PicUrl = "http://www.sxajj.gov.cn/1.jpg";
                    article.Url = "http://www.sxajj.gov.cn/1.jpg";
                    articles.Add(article);
                    article = new ArticlesModel();
                    article.Title = string.Format("二号项目\n项目编号：CX2502;验收状态:完成;验收结果:通过;");
                    article.PicUrl = "http://www.sxajj.gov.cn/1.jpg";
                    article.Url = "http://www.sxajj.gov.cn/1.jpg";
                    articles.Add(article);
                    ProduceNews(model, articles);
                    break;
                case "3":
                    //生成图片
                    string mediaId = "IBH9UW7Ptrvbs9rQHAnu2zonxeq5Jh0uL6WwuYauIEWNF0UlyVMecLV3ploxRc5X";
                    ProduceImage(model, mediaId);
                    break;
                case "4":
                    ReplayTemplete(model);
                    break;
                case "5":
                    ReplaySubscribeText(model);
                    break;
            }
        }

        /// <summary>
        ///  回复关注事件的消息
        /// </summary>
        /// <param name="model">The model.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 14:10:31
        public static void ReplaySubscribeText(Dictionary<string, string> model)
        {
            List<ArticlesModel> articles = new List<ArticlesModel>();
            ArticlesModel article = new ArticlesModel();
            article.Title = "欢迎关注绍兴标点电子公司";
            articles.Add(article);
            article = new ArticlesModel();
            article.Title = "【公司介绍】\n开发、销售：电子产品、工控设备；开发：电脑软件；销售：电脑及耗材；计算机软硬件的技术咨询、技术服务、技术转让。";
            articles.Add(article);
            article = new ArticlesModel();
            article.Title = "【公司地址】\n中国浙江省绍兴市越城区舜江路683号科创大厦705室";
            articles.Add(article);
            article = new ArticlesModel();
            article.Title = "【公司微信】\nShaoXinBiaoDian";
            articles.Add(article);
            ProduceNews(model, articles);
        }

        /// <summary>
        ///  使用官方模版借口
        /// </summary>
        /// <param name="model">The model.</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-10-24 16:13:13
        public static void ReplayTemplete(Dictionary<string, string> model)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=gITQNRtcDKDX6Lsv3k5WUy537xmBZNp8i3kpLZ0WWdFHKKW0y1Ps165q4_gVca-Z1YPtg8I2KWDmWxrFDoDDAJw4Qp4Aw2x69UQHAa0fVCw";
            StringBuilder json = new StringBuilder();
            json.Append("{\"touser\":\"");
            json.AppendFormat("{0}", model.ReadKey(PublicField.FromUserName));
            json.Append("\",\"template_id\":\"JUif5V5O1PEhmdl8IDsNNlS6xVp_yHNSq0PIh8F9iTk\",\"url\":\"http://www.sxajj.gov.cn/1.jpg\",\"topcolor\":\"#FF0000\",\"data\":{\"first\": {\"value\":\"您好，您有一条工单审核反馈\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"OA20140830123456\",\"color\":\"#173177\"},\"keyword2\":{\"value\":\"关于某文件的审批审阅\",\"color\":\"#173177\"},\"keyword3\":{\"value\":\"待审核\",\"color\":\"#173177\"},\"keyword4\":{\"value\":\"20140830093014\",\"color\":\"#173177\"},\"keyword5\":{\"value\":\"20140831093014\",\"color\":\"#173177\"},\"remark\":{\"value\":\"请点击查看审核结果。\",\"color\":\"#173177\"}}}");
            PublicFun.RequestUpDownData(url, HttpMethod.Post, json.ToString());
        }


    }
}
