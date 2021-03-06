﻿/**
* ProductUploadImgHandler.cs
*
* 功 能： 产品上传图片
* 类 名： ProductUploadImgHandler
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/7/1 19:52:00    Ben    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：小鸟科技（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using YSWL.MALL.BLL.SysManage;
using YSWL.Common;
using YSWL.MALL.Model.SysManage;
using System.IO;

namespace YSWL.MALL.Web.Handlers.CMS
{
    public class UploadPhotoHandler : UploadImageHandlerBase
    {
                 public UploadPhotoHandler()
        {
            string StoreWay = BLL.SysManage.ConfigSystem.GetValueByCache("CMS_ImageStoreWay");
            if (StoreWay == "1")
            {
                IsLocalSave = false;
                ApplicationKeyType = ApplicationKeyType.CMS;
            }
        }

        protected override List<YSWL.MALL.Model.Ms.ThumbnailSize> GetThumSizeList()
        {
            return YSWL.MALL.BLL.Ms.ThumbnailSize.GetThumSizeList(Model.Ms.EnumHelper.AreaType.CMS, MvcApplication.ThemeName);
        }

        public static string CreateIDCode()
        {
            DateTime Time1 = DateTime.Now.ToUniversalTime();
            DateTime Time2 = Convert.ToDateTime("1970-01-01");
            TimeSpan span = Time1 - Time2;   //span就是两个日期之间的差额
            string t = span.TotalMilliseconds.ToString("0");
            return t;
        }

        protected override void ProcessSub(HttpContext context, string uploadPath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Params["album"])) return;
            string albumId = context.Request.Params["album"];

            if (string.IsNullOrWhiteSpace(context.Request.Params["userId"])) return;
            string userId = context.Request.Params["userId"];

            string folder = @context.Request.Params["folder"];

            BLL.CMS.Photo bll = new BLL.CMS.Photo();
            HttpPostedFile file = context.Request.Files["Filedata"];


            string savePath = folder + DateTime.Now.ToString("yyyyMMdd") + "/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(savePath)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(savePath));
            }
           
            string ImageUrl = savePath + fileName;
            string ThumbImageUrl = savePath + "{0}" + fileName;
            string NormalImageUrl = "";
            //下面是如果是网络存储
            if (!IsLocalSave)
            {
                ImageUrl = fileName;
                ThumbImageUrl = ImageUrl;
            }
            Model.CMS.Photo model = new Model.CMS.Photo
            {
                PhotoName = file.FileName,
                ImageUrl = ImageUrl,
                Description = "",
                AlbumID = int.Parse(albumId),
                State = 1,
                CreatedUserID = int.Parse(userId),
                CreatedDate = DateTime.Now,
                PVCount = 0,
                ClassID = 1,
                ThumbImageUrl = ThumbImageUrl,
                NormalImageUrl = NormalImageUrl,
                Sequence = bll.GetMaxSequence(),
                IsRecomend = false,
                CommentCount = 0,
                Tags = ""
            };

            //ArrayList imageList = new ArrayList();
            //imageList.Add("/" + fileName);
            //imageList.Add("/" + "T_" + fileName);
            //imageList.Add("/" + "N_" + fileName);

            int iId = bll.Add(model);
            if (iId > 0 && IsLocalSave)
            {
                try
                {
                    //首先移动原图片
                    string uploadUrl = uploadPath + fileName;
                    string uploadThumUrl = uploadPath + "{0}" + fileName;
                    if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(uploadUrl)))
                    {
                        System.IO.File.Move(HttpContext.Current.Server.MapPath(uploadUrl), HttpContext.Current.Server.MapPath(ImageUrl));
                    }
                    List<YSWL.MALL.Model.Ms.ThumbnailSize> ThumbSizeList =
                   YSWL.MALL.BLL.Ms.ThumbnailSize.GetThumSizeList(YSWL.MALL.Model.Ms.EnumHelper.AreaType.CMS, MvcApplication.ThemeName);
                    if (ThumbSizeList != null && ThumbSizeList.Count > 0)
                    {
                        string destImage = "";
                        foreach (var thumbSize in ThumbSizeList)
                        {
                            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(String.Format(uploadThumUrl, thumbSize.ThumName))))
                            {
                                destImage = String.Format(ThumbImageUrl, thumbSize.ThumName);
                                System.IO.File.Move(HttpContext.Current.Server.MapPath(String.Format(uploadThumUrl, thumbSize.ThumName)), HttpContext.Current.Server.MapPath(destImage));

                            }
                        }
                    }
                    //将图片从临时文件夹移动到正式的文件夹下
                   // Common.FileManage.MoveFile(System.Web.HttpContext.Current.Server.MapPath(uploadPath), System.Web.HttpContext.Current.Server.MapPath(savePath), imageList);
                }
                catch (Exception)
                {
                }
            }

            //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
            context.Response.Write(iId.ToString());

            //context.Response.Write("1|" + uploadPath + "{0}" + fileName);
        }
        /// <summary>
        /// 移动图片文件
        /// </summary>
        /// <param name="ImageUrl"></param>
        /// <param name="savePath"></param>
        /// <param name="saveThumbsPath"></param>
        /// <returns></returns>
        public  string MoveImage(string ImageUrl, string savePath, string saveThumbsPath)
        {
            try
            {
                if (BLL.SysManage.ConfigSystem.GetValueByCache("CMS_ImageStoreWay") == "1")
                {
                    return ImageUrl + "|" + ImageUrl;
                }
                if (!string.IsNullOrEmpty(ImageUrl))
                {

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(savePath)))
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(savePath));

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(saveThumbsPath)))
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(saveThumbsPath));

                    List<YSWL.MALL.Model.Ms.ThumbnailSize> ThumbSizeList =
                        YSWL.MALL.BLL.Ms.ThumbnailSize.GetThumSizeList(YSWL.MALL.Model.Ms.EnumHelper.AreaType.CMS, MvcApplication.ThemeName);

                    string imgname = ImageUrl.Substring(ImageUrl.LastIndexOf("/") + 1);
                    string destImage = "";
                    string originalUrl = "";
                    string thumbUrl = saveThumbsPath + imgname;
                    //首先移动原图片

                    if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(String.Format(ImageUrl, ""))))
                    {
                        originalUrl = String.Format(savePath + imgname, "");
                        System.IO.File.Move(HttpContext.Current.Server.MapPath(String.Format(ImageUrl, "")), HttpContext.Current.Server.MapPath(originalUrl));
                    }
                    if (ThumbSizeList != null && ThumbSizeList.Count > 0)
                    {
                        foreach (var thumbSize in ThumbSizeList)
                        {
                            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(String.Format(ImageUrl, thumbSize.ThumName))))
                            {
                                destImage = String.Format(thumbUrl, thumbSize.ThumName);
                                System.IO.File.Move(HttpContext.Current.Server.MapPath(String.Format(ImageUrl, thumbSize.ThumName)), HttpContext.Current.Server.MapPath(destImage));

                            }
                        }
                    }
                    return originalUrl + "|" + thumbUrl;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }
    }
}