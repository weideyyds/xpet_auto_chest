# XPET自动每日任务小工具使用教程
1.工具目录结构

![image](https://github.com/weideyyds/xpet_auto_chest/assets/155040240/9f972b52-b105-4595-ba96-65305cdab284)

目录结构如上图，
Authorization.txt是存放xpet授权信息的文件，
ids.txt是回复过评论的推文ID文件
MD5验证工具.exe这个是验证文件的md5的，md5我将放到Releases的版本描述里面，请大家仔细核对，如果md5值不正确，可能文件已经被非法修改了
xpet自动每日任务_V1.0.exe是主要执行的exe文件

2.获取Authorization
使用Chrome浏览器打开xpet的app版本
地址：https://app.xpet.tech/
然后登录，登陆成功之后如下图
![image](https://github.com/weideyyds/xpet_auto_chest/assets/155040240/ee5a6e6d-00da-4964-ae34-5d6c6dcb77b2)

然后按下键盘快捷键F12
![image](https://github.com/weideyyds/xpet_auto_chest/assets/155040240/3f0bce79-3daa-4dbb-8844-1e9aa4c4e0e2)


如图标识，点击Network,然后点击Fetc/XHR
![image](https://github.com/weideyyds/xpet_auto_chest/assets/155040240/683f085c-7d8f-46f7-9055-168d2dff9ad5)


找到getUserInfo这个，点击它，会出来右边的一些信息，复制Bearer开头的这一段信息到Authorization.txt进行保存

3.评论推文并保存推文id
随便找一个推文，可以是别人的，也可以是你自己的推文，进行评论，目前要求评论16个字符以上，其中包含xpet字符。
评论过后，如图所示，复制框选部分数字就是推文Id到ids.txt文件中，每一行一个，可以操作三个ID，这三个ID必须是不同推文
![image](https://github.com/weideyyds/xpet_auto_chest/assets/155040240/be0f53b1-b58c-4c62-bc72-efcf6ec8e1cf)


4.成功提示
如果成功了就会显示得到的任务奖励，如果有错误请反馈给我
下图就是已经完成任务领取过宝箱的情况
![image](https://github.com/weideyyds/xpet_auto_chest/assets/155040240/663ec909-6e6d-437a-b4bb-c7b910f3a8de)
