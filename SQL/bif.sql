/*
 Navicat Premium Data Transfer

 Source Server         : localHaoSqlMyql
 Source Server Type    : MySQL
 Source Server Version : 50719
 Source Host           : localhost:3306
 Source Schema         : bif

 Target Server Type    : MySQL
 Target Server Version : 50719
 File Encoding         : 65001

 Date: 19/12/2019 12:53:40
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for bif_company
-- ----------------------------
DROP TABLE IF EXISTS `bif_company`;
CREATE TABLE `bif_company`  (
  `id` bigint(20) NOT NULL,
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '统一社会信用代码',
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '名称',
  `type` int(4) NULL DEFAULT NULL COMMENT '企业类型',
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `tel` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `fax` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `zip` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮编',
  `email` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `website` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `person` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '负责人',
  `state` int(4) NULL DEFAULT 0,
  `rdt` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '记录时间',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '公司表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of bif_company
-- ----------------------------
INSERT INTO `bif_company` VALUES (299935790530603, 'bif', '张学友公司', 1, '河南省邓州市', '0377-62958337', '0377-62958337', '474172', 'dym6295@163.com', 'http://ok.com', '杜燕明', 0, '2016-07-17 11:41:00');
INSERT INTO `bif_company` VALUES (299935790530604, 'ndtech', '北京恩维协同', 1, '北京市朝阳区', '010-62958337', '010-62958337', '10000', 'duyanming@ndtech.com', 'http://www.ndtech.com.cn', '王五', 0, '2016-10-02 11:41:00');

-- ----------------------------
-- Table structure for bif_log
-- ----------------------------
DROP TABLE IF EXISTS `bif_log`;
CREATE TABLE `bif_log`  (
  `id` bigint(8) NOT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '日志名称',
  `user` bigint(8) NULL DEFAULT NULL COMMENT '操作人',
  `type` int(4) NULL DEFAULT NULL COMMENT '操作类型',
  `ip` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作人IP',
  `content` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作内容',
  `timespan` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member`  (
  `id` bigint(20) NOT NULL COMMENT '主键',
  `code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '编号',
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '名称',
  `birthday` datetime(6) NULL DEFAULT NULL COMMENT '出生日期',
  `sex` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '性别',
  `chinesezodiac` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '生肖',
  `maritalstatus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '婚姻状况',
  `faith` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '宗教信仰',
  `annualincome` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '年收入',
  `reside` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '居住区域',
  `hometown` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '家乡',
  `background` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '家庭出身',
  `alone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '独生子女',
  `educational` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '毕业院校',
  `higeducational` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '最高学历',
  `vocation` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '行业',
  `position` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '职位',
  `housingsituation` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '购房情况',
  `purcar` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '购车情况',
  `lifestyle` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '生活习惯',
  `hobby` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '爱好',
  `selfassessment` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '自我评价',
  `idealperson` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '理想中的他',
  `idcardpic` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '身份证照片',
  `degreepic` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '学历照片',
  `personalpic` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '个人照片',
  `qrcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '微信二维码',
  `suggest` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '建议',
  `rdt` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member
-- ----------------------------
INSERT INTO `member` VALUES (297367665125568512, 'admin', 'admin', '2019-04-06 00:00:00.000000', '女', '鼠', '未婚', '无', '5万--10万', '华南区', '天津', '资产阶级', '否', '开封大学', '博士', '房地产', '总监', '保密', '保密', '生活习惯（作息、饮食）', '生活习惯（作息、饮食）', '自我评价', '理想中的TA', '', '', '', 'images/297367665097404416-qrcode-duruoyi.com.certificate.jpg', '', '2019-04-13 03:29:12.140001');
INSERT INTO `member` VALUES (297367730611507200, '阿英煲聊天', '阿英煲聊天', '2019-04-13 00:00:00.000000', '女', '鼠', '未婚', '无', '5万--10万', '华南区', '天津', '资产阶级', '否', '开封大学', '博士', '房地产', '总监', '保密', '保密', '去', '饿', '哦', '她', 'images/297367726120992768-idcardpic-16-08-26-CSType.gif', 'images/297367726033305600-degreepic-1524231601166.jpg', 'images/297367725415317504-personalpic-WechatQRCode.png', 'images/297367725236592640-qrcode-21-59-25-705728-20160424234824085-667046040.png', '微信', '2019-04-13 07:55:39.972024');
INSERT INTO `member` VALUES (297367901547139072, '杜燕明', '杜燕明', '2019-04-12 00:00:00.000000', '女', '鼠', '未婚', NULL, '70万以下', '北京-北京-东城区', '北京-北京-东城区', '工人阶级', '是', ',开封大学', '大专', '金融', '经纪人', '无房', '无车', '111', '222', '333', '444', '', '', 'images/297367901391360000-personalpic-303W170228A02-029.jpg', 'images/297367900945264640-qrcode-duruoyi.com.certificate.jpg', '', '2019-04-13 19:31:12.305929');
INSERT INTO `member` VALUES (297367906522406912, '123', '123', '2019-04-13 00:00:00.000000', '女', '鼠', '未婚', NULL, '70万以下', '北京-北京-怀柔区', '北京-北京-东城区', '工人阶级', '是', ',让人', '大专', '金融', '让人', '无房', '无车', '去', 'qq', 'qq', 'qq', '', '', '', 'images/297367906509836288-qrcode-21-59-25-705728-20160424234824085-667046040.png', '', '2019-04-13 19:51:26.914179');
INSERT INTO `member` VALUES (297368954581065728, '阿三', '阿三', '1999-04-16 00:00:00.000000', '女', '鼠', '未婚', '请选择', '12万以下', '北京-北京-东城区', '北京-北京-东城区', '请选择', '是', '哈哈院校', '自考本科', '金融', '请选择', '无房', '无车', '123', '456', '789', '369', '', '', '', 'images/297368954464268288-qrcode-IMG_20181118_062342.jpg', '', '2019-04-16 18:56:00.665167');
INSERT INTO `member` VALUES (297368959870038016, '666', '666', '2016-04-19 00:00:00.000000', '女', '鼠', '未婚', '佛教', '12万以下', '北京-北京-东城区', '北京-北京-东城区', '请选择', '是', '6666', '自考本科', '金融', '普通干部', '无房有购买能力', '无车摇号中', '3333', '3333', '333', '3333', '', '', '', 'images/297368959619604480-qrcode-duruoyi.com.certificate.jpg', '', '2019-04-16 19:17:31.919855');

-- ----------------------------
-- Table structure for sys_func
-- ----------------------------
DROP TABLE IF EXISTS `sys_func`;
CREATE TABLE `sys_func`  (
  `id` bigint(20) NOT NULL,
  `fname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `fcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `forder` float(50, 0) NULL DEFAULT NULL,
  `pid` bigint(20) NULL DEFAULT NULL,
  `furl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `show` smallint(2) NULL DEFAULT 1,
  `icon` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_func
-- ----------------------------
INSERT INTO `sys_func` VALUES (47826128347136, 'NetMQ', 'netmq', 8, 299935790530590, 'https://netmq.readthedocs.io/en/latest/', 1, '');
INSERT INTO `sys_func` VALUES (49552713900032, '品美空间', 'pmkjroot', 2, NULL, 'http://test.pmpai.com/pmeiweb/', 1, '');
INSERT INTO `sys_func` VALUES (49552772186112, '品美空间', 'pmkj', 2, 49552713900032, 'http://test.biswit.com/pmeiweb/', 1, '');
INSERT INTO `sys_func` VALUES (100876538834944, 'k8s', 'k8s', 1, 299935790530590, '', 1, '');
INSERT INTO `sys_func` VALUES (100878287302656, 'jimmysong', 'k8s', 2, 100876538834944, 'https://jimmysong.io/kubernetes-handbook/', 1, '');
INSERT INTO `sys_func` VALUES (101163644395520, 'k8s-Centos7 搭建', 'k8s', 3, 100876538834944, 'http://www.maogx.win/posts/32/', 0, '');
INSERT INTO `sys_func` VALUES (101163940139008, '每天5分钟玩转 Kubernetes', 'k8s', 1, 100876538834944, 'https://mp.weixin.qq.com/s/RK6DDc8AUBklsUS7rssW2w', 0, '');
INSERT INTO `sys_func` VALUES (101164278681600, 'k8s-dashboard', 'k8s', 4, 100876538834944, 'https://www.cnblogs.com/RainingNight/p/deploying-k8s-dashboard-ui.html', 0, '');
INSERT INTO `sys_func` VALUES (101990373568512, '品美495价目表', 'pmpricetest', 2, 49552713900032, 'html/pm/index.html?model=live&code=300798', 1, '');
INSERT INTO `sys_func` VALUES (109378174894080, '43价目表', 'cpjpricetest', 2, 49552713900032, 'html/pm/index.html?model=live&code=300043', 1, '');
INSERT INTO `sys_func` VALUES (111791689408512, '43供应商采购单', 'polist', 2, 49552713900032, 'html/pm/po.html?model=live&code=300043&funcId=4f388cd914da4c91a910be6061736770', 1, '');
INSERT INTO `sys_func` VALUES (132054338420736, '系统监控', 'xtjk', 2, NULL, '', 1, 'el-icon-setting');
INSERT INTO `sys_func` VALUES (132054501289984, '调用链追踪', 'dylzz', 1, 132054338420736, 'html/trace/index.html', 1, '');
INSERT INTO `sys_func` VALUES (132054881103872, '系统CPU-Memory监控', 'cm', 2, 132054338420736, '/html/welcome.html', 1, '');
INSERT INTO `sys_func` VALUES (299935790530579, '会员列表', 'mlist', 1, 299935790530582, 'html/mlist.html', 1, '../js/lib/ligerUI/skins/icons/memeber.gif');
INSERT INTO `sys_func` VALUES (299935790530580, '系统管理', 'sysm', 99999, NULL, '', 1, 'el-icon-menu');
INSERT INTO `sys_func` VALUES (299935790530582, '系统会员', 'sys_m', 0, 299935790530580, '', 1, '../js/lib/ligerUI/skins/icons/memeber.gif');
INSERT INTO `sys_func` VALUES (299935790530583, '系统配置', 'sys_roles', 1, 299935790530580, '', 1, '');
INSERT INTO `sys_func` VALUES (299935790530584, '角色功能配置', 'frc', 1, 299935790530583, 'html/func_roles_config.html', 1, '../js/lib/ligerUI/skins/icons/memeber.gif');
INSERT INTO `sys_func` VALUES (299935790530585, '公司列表', 'componylist', 0, 299935790530582, 'html/carrier.html?Tname=colist', 1, '');
INSERT INTO `sys_func` VALUES (299935790530586, '功能点配置', 'sys_func_config', 1, 299935790530583, 'html/fconfig.html', 1, '');
INSERT INTO `sys_func` VALUES (299935790530590, '查阅资料', 'lsfzl', 3, NULL, '', 1, 'el-icon-location');
INSERT INTO `sys_func` VALUES (299935790530591, '李山峰', 'lsfzl', 1, 299935790530590, 'http://60.205.210.195', 0, '');
INSERT INTO `sys_func` VALUES (299935790530592, 'Redis', 'lsfzl', 2, 299935790530590, 'http://doc.redisfans.com/', 1, '');
INSERT INTO `sys_func` VALUES (299935790530593, 'MongoDB-csharp', 'lsfzl', 3, 299935790530590, 'https://docs.mongodb.com/getting-started/csharp/', 1, '');
INSERT INTO `sys_func` VALUES (299935790530594, 'ECMAScript 6', 'lsfzl', 4, 299935790530590, 'http://es6.ruanyifeng.com/', 1, '');
INSERT INTO `sys_func` VALUES (299935790530595, '内涵段子', 'joker', 5, 299935790530590, 'html/Joker/beauty.html', 1, '');
INSERT INTO `sys_func` VALUES (2975002949320704, 'Rabbitmq', 'rabbitmq', 6, 299935790530590, 'https://www.rabbitmq.com/getstarted.html', 1, '');
INSERT INTO `sys_func` VALUES (3957341116563456, 'postgresql', 'postgresqltutorial', 7, 299935790530590, 'http://www.postgresqltutorial.com', 1, '');

-- ----------------------------
-- Table structure for sys_func_roles_link
-- ----------------------------
DROP TABLE IF EXISTS `sys_func_roles_link`;
CREATE TABLE `sys_func_roles_link`  (
  `id` bigint(20) NOT NULL,
  `fid` bigint(20) NULL DEFAULT NULL,
  `rid` bigint(20) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_func_roles_link
-- ----------------------------
INSERT INTO `sys_func_roles_link` VALUES (47826205687822, 47826128347136, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (48079821643776, 299935790530581, 48079494410240);
INSERT INTO `sys_func_roles_link` VALUES (48079821643777, 299935790530589, 48079494410240);
INSERT INTO `sys_func_roles_link` VALUES (48079821643778, 299935790530587, 48079494410240);
INSERT INTO `sys_func_roles_link` VALUES (48079821643779, 299935790530588, 48079494410240);
INSERT INTO `sys_func_roles_link` VALUES (49553696141318, 49552713900032, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (54144497336340, 54144308453376, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (55156999446537, 55156839686144, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (100878479306760, 100876538834944, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (100878479306761, 100878287302656, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (101164434472970, 101163940139008, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (101164434472972, 101163644395520, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (101164434472973, 101164278681600, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (101991211909127, 101990373568512, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (109378342379528, 109378174894080, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (111791747018759, 111791689408512, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (123920583868416, 299935790530590, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (123920583868417, 55156839686144, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (127005557727239, 49552772186112, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (132054955646982, 132054338420736, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (132054955646983, 132054501289984, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (132054955646984, 132054881103872, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530605, 299935790530579, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530606, 299935790530580, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530607, 299935790530581, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530608, 299935790530582, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530609, 299935790530583, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530610, 299935790530584, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530611, 299935790530585, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530612, 299935790530586, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530613, 299935790530587, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530614, 299935790530588, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530615, 299935790530589, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530616, 299935790530590, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530617, 299935790530591, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530618, 299935790530592, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530619, 299935790530593, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530620, 299935790530594, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530621, 299935790530595, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530622, 299935790530596, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530623, 299935790530597, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530624, 299935790530598, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530625, 299935790530599, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530626, 299935790530600, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (299935790530627, 299935790530601, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (313598404460544, 299935790530596, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (313598404460545, 299935790530597, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (313598404460546, 299935790530598, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (313598404460547, 299935790530600, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (313598404460548, 299935790530601, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (313598404460549, 299935790530599, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (1229232533405702, 299935790530590, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (1229232533405703, 299935790530591, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (1229232533405704, 299935790530592, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (1229232533405705, 299935790530593, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (1229232533405706, 299935790530594, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (1229232533405707, 299935790530595, 299935790530575);
INSERT INTO `sys_func_roles_link` VALUES (2975114438115340, 2975002949320704, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (3957546389995533, 3957341116563456, 299935790530574);
INSERT INTO `sys_func_roles_link` VALUES (13892844284542976, 299935790530580, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (13892844284542977, 299935790530582, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (13892844284542978, 299935790530585, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (13892844284542979, 299935790530579, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (31222381003407360, 299935790530581, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (31222381003407361, 299935790530589, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (31222381003407362, 299935790530587, 299935790530578);
INSERT INTO `sys_func_roles_link` VALUES (31222381003407363, 299935790530588, 299935790530578);

-- ----------------------------
-- Table structure for sys_member
-- ----------------------------
DROP TABLE IF EXISTS `sys_member`;
CREATE TABLE `sys_member`  (
  `id` bigint(20) NOT NULL,
  `account` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `pwd` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `coid` bigint(20) NOT NULL DEFAULT -1 COMMENT '公司ID',
  `position` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `state` smallint(1) NULL DEFAULT 1 COMMENT '1 启用 0 禁用',
  `profile` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `timespan` datetime(0) NULL DEFAULT NULL,
  `rdt` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '注册时间',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_member
-- ----------------------------
INSERT INTO `sys_member` VALUES (49552092442624, 'jiangwen', 'nsiFvHyFuoM=', 0, '导演', '姜文', 1, 'b3133ecec9794867989bd98491872354', '2018-12-25 12:00:14', '2018-08-28 13:40:46');
INSERT INTO `sys_member` VALUES (60545176104960, 'qbs', 'nsiFvHyFuoM=', 0, '架构师', '乔布斯', 1, 'HAqvhBLt3SGTGvu4T1RUDl6ZgzwJTsIL0jUysXN16HVyciYdvKWGKA==', '2019-12-19 12:45:58', '2018-09-28 15:11:44');
INSERT INTO `sys_member` VALUES (299935786336256, 'admin', 'nsiFvHyFuoM=', 299935790530603, '.NET 工程师', '杜燕明', 1, 'mZEyRTJP5DuQaR4rsl00X/s9juc1wzK+q4w4nxkLdsXvq2G8zBAbm8D32nrhKWAT', '2019-11-06 10:07:58', '2016-07-11 22:52:57');
INSERT INTO `sys_member` VALUES (299935790530560, 'yrm', 'nsiFvHyFuoM=', 299935790530603, 'BIF主管', '于瑞敏', 0, 'e23558cd3cec43bd8dd7ab5bb7cd0aae', '2019-03-26 17:07:04', '2016-07-12 22:52:57');
INSERT INTO `sys_member` VALUES (299935790530561, 'duyanming', 'nsiFvHyFuoM=', 299935790530604, 'TestPostion', 'DuYanming', 0, 'af15f81694e64513b9ed99c5b8a84ad9', '2016-07-06 22:09:15', '2016-07-13 22:52:57');
INSERT INTO `sys_member` VALUES (299935790530562, 'bjcz', 'myjMrb9Iey8=', 299935790530604, '管理员', '北京传智播客', 0, '02db5beda74a46b0bd0b7bee7bf29fd1', '2016-07-10 08:59:50', '2016-07-14 22:52:57');
INSERT INTO `sys_member` VALUES (299935790530563, 'lishanfeng', 'nsiFvHyFuoM=', 299935790530603, '全栈工程师', '王大锤', 1, 'fSFhFv5d4ZnxJ12sqaTR3ilrblZkOwmbmQpcII9q62mIcUZZbjW7Nedxgj4kw+Nz', '2019-10-10 09:36:52', '2016-12-27 15:44:54');
INSERT INTO `sys_member` VALUES (299935790530564, 'xijinping', 'myjMrb9Iey8=', 299935790530604, '第一老大', '习近平', 1, '8e72c9ce0b5b45158032a78b514a2f05', '2017-01-14 17:35:01', '2017-01-10 10:48:15');
INSERT INTO `sys_member` VALUES (299935790530565, '123', 'myjMrb9Iey8=', 299935790530603, '123', '123', 0, NULL, NULL, '2017-01-12 10:18:58');
INSERT INTO `sys_member` VALUES (299935790530566, 'User1', 'myjMrb9Iey8=', 299935790530604, 'CEO', 'Updateable', 1, NULL, NULL, '2017-02-15 14:03:01');
INSERT INTO `sys_member` VALUES (299935790530567, 'tlp', 'nsiFvHyFuoM=', 299935790530603, '美国总统', '特朗普·川普', 0, '33d6e1bdbde2471bb887fb7d47dc56ca', '2018-04-14 20:09:49', '2017-02-22 10:31:14');
INSERT INTO `sys_member` VALUES (299935790530568, '18510994063', 'nsiFvHyFuoM=', 0, '玩家', '王五', 1, NULL, NULL, NULL);
INSERT INTO `sys_member` VALUES (299935790530569, '1', 'jvnKWN3f6mU=', 0, '1', '老刘', 1, '2e750e5a0d9244f1b0ec7385b92c7ecd', '2018-05-05 18:34:10', NULL);
INSERT INTO `sys_member` VALUES (299935790530570, 'laosan', 'jvnKWN3f6mU=', 0, '12', '老三', 1, 'a4a5e22112634c5ea9cbdfc1a086f283', '2018-10-31 17:48:17', NULL);

-- ----------------------------
-- Table structure for sys_member_roles_link
-- ----------------------------
DROP TABLE IF EXISTS `sys_member_roles_link`;
CREATE TABLE `sys_member_roles_link`  (
  `id` bigint(20) NOT NULL,
  `mid` bigint(20) NULL DEFAULT NULL,
  `rid` bigint(20) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_member_roles_link
-- ----------------------------
INSERT INTO `sys_member_roles_link` VALUES (49552092565504, 49552092442624, 48079494410240);
INSERT INTO `sys_member_roles_link` VALUES (60545176219648, 60545176104960, 299935790530575);
INSERT INTO `sys_member_roles_link` VALUES (65063157125120, 299935790530563, 299935790530574);
INSERT INTO `sys_member_roles_link` VALUES (144703322042368, 60545176104960, 299935790530574);
INSERT INTO `sys_member_roles_link` VALUES (299935790530573, 299935786336256, 299935790530574);
INSERT INTO `sys_member_roles_link` VALUES (314193764941824, 299935790530567, 299935790530575);
INSERT INTO `sys_member_roles_link` VALUES (1227636298743808, 299935790530566, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1227732721598464, 299935790530565, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1227813260623872, 299935790530564, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1227977350184960, 299935790530562, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1228043624382464, 299935790530561, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1228111601467392, 299935790530560, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1228205608402944, 299935790530570, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1228268883673088, 299935790530569, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (1228325875875840, 299935790530568, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (13892695328030720, 299935790530563, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (35462212902453248, 299935786336256, 299935790530577);
INSERT INTO `sys_member_roles_link` VALUES (35462213049253888, 299935786336256, 299935790530578);
INSERT INTO `sys_member_roles_link` VALUES (35462213061836800, 299935786336256, 299935790530575);
INSERT INTO `sys_member_roles_link` VALUES (35462213078614016, 299935786336256, 299935790530576);
INSERT INTO `sys_member_roles_link` VALUES (36694368303710208, 299935790530564, 299935790530575);

-- ----------------------------
-- Table structure for sys_roles
-- ----------------------------
DROP TABLE IF EXISTS `sys_roles`;
CREATE TABLE `sys_roles`  (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_roles
-- ----------------------------
INSERT INTO `sys_roles` VALUES (48079494410240, '体验者');
INSERT INTO `sys_roles` VALUES (299935790530574, 'System');
INSERT INTO `sys_roles` VALUES (299935790530575, '管理员');
INSERT INTO `sys_roles` VALUES (299935790530576, '供应商');
INSERT INTO `sys_roles` VALUES (299935790530577, '采购商');
INSERT INTO `sys_roles` VALUES (299935790530578, '玩家');

-- ----------------------------
-- Table structure for sys_trace
-- ----------------------------
DROP TABLE IF EXISTS `sys_trace`;
CREATE TABLE `sys_trace`  (
  `id` bigint(20) NOT NULL,
  `GlobalTraceId` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `TraceId` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '调用链唯一标识',
  `PreTraceId` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '上级调用链唯一标识',
  `AppNameTarget` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '目标App名称',
  `AppName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'App名称',
  `TTL` int(10) NULL DEFAULT NULL COMMENT '跳转次数',
  `Request` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '请求参数',
  `Response` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '响应参数',
  `Ip` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作人IP',
  `Target` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '目标地址',
  `UserId` bigint(20) NULL DEFAULT NULL COMMENT '操作人ID',
  `Timespan` datetime(6) NULL DEFAULT NULL COMMENT '记录时间',
  `Askchannel` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '请求管道',
  `Askrouter` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '请求路由',
  `Askmethod` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '业务方法',
  `Uname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '用户名',
  `UseTimeMs` double(28, 0) NULL DEFAULT -1,
  `Rlt` tinyint(1) NULL DEFAULT 1 COMMENT '处理结果',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Function structure for getChildList
-- ----------------------------
DROP FUNCTION IF EXISTS `getChildList`;
delimiter ;;
CREATE FUNCTION `getChildList`(rootId VARCHAR(50))
 RETURNS varchar(1000) CHARSET utf8
  READS SQL DATA 
BEGIN
  DECLARE sTemp VARCHAR(1000);

  DECLARE sTempChd VARCHAR(1000);

  SET sTemp = '$';

  SET sTempChd =cast(rootId as CHAR);

  WHILE sTempChd is not null DO

    SET sTemp = concat(sTemp,',',sTempChd);

    SELECT group_concat(TraceId) INTO sTempChd FROM sys_trace where FIND_IN_SET(PreTraceId,sTempChd)>0;

  END WHILE;

  RETURN sTemp;

END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
