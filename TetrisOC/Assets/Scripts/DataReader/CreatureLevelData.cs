using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CreatureLevelData{
/// <summary>
/// 等级
/// </summary>
public int Level;
/// <summary>
/// 升级花费
/// </summary>
public string CostID;
/// <summary>
/// 重置花费
/// </summary>
public int ResetCostID;
public CreatureLevelData(int Level, string CostID, int ResetCostID){
this.Level = Level;
this.CostID = CostID;
this.ResetCostID = ResetCostID;
}
class CreatureLevelDataReader{
static CreatureLevelDataReader instance;
static object syncRoot = new object();
public static CreatureLevelDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CreatureLevelDataReader();instance.Load();}}}return instance;}}
Dictionary<int, CreatureLevelData> root = new Dictionary<int, CreatureLevelData>();
void Load(){
root.Add(1, new CreatureLevelData(1, "1", 27006));
root.Add(2, new CreatureLevelData(2, "20", 27006));
root.Add(3, new CreatureLevelData(3, "172", 27006));
root.Add(4, new CreatureLevelData(4, "718", 27006));
root.Add(5, new CreatureLevelData(5, "2270", 27006));
root.Add(6, new CreatureLevelData(6, "5520", 27006));
root.Add(7, new CreatureLevelData(7, "12257", 27006));
root.Add(8, new CreatureLevelData(8, "22448", 27006));
root.Add(9, new CreatureLevelData(9, "38646", 27006));
root.Add(10, new CreatureLevelData(10, "56625", 27006));
root.Add(11, new CreatureLevelData(11, "81818", 27006));
root.Add(12, new CreatureLevelData(12, "118523", 27006));
root.Add(13, new CreatureLevelData(13, "172161", 27006));
root.Add(14, new CreatureLevelData(14, "252584", 27006));
root.Add(15, new CreatureLevelData(15, "376358", 27006));
root.Add(16, new CreatureLevelData(16, "570071", 27006));
root.Add(17, new CreatureLevelData(17, "877216", 27006));
root.Add(18, new CreatureLevelData(18, "1370312", 27006));
root.Add(19, new CreatureLevelData(19, "2165562", 27006));
root.Add(20, new CreatureLevelData(20, "3452889", 27007));
root.Add(21, new CreatureLevelData(21, "5541782", 27007));
root.Add(22, new CreatureLevelData(22, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(23, new CreatureLevelData(23, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(24, new CreatureLevelData(24, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(25, new CreatureLevelData(25, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(26, new CreatureLevelData(26, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(27, new CreatureLevelData(27, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(28, new CreatureLevelData(28, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(29, new CreatureLevelData(29, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(30, new CreatureLevelData(30, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(31, new CreatureLevelData(31, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(32, new CreatureLevelData(32, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(33, new CreatureLevelData(33, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(34, new CreatureLevelData(34, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(35, new CreatureLevelData(35, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(36, new CreatureLevelData(36, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(37, new CreatureLevelData(37, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(38, new CreatureLevelData(38, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(39, new CreatureLevelData(39, "48*x*((19*x+3)+POW(1.5,x))", 27007));
root.Add(40, new CreatureLevelData(40, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(41, new CreatureLevelData(41, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(42, new CreatureLevelData(42, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(43, new CreatureLevelData(43, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(44, new CreatureLevelData(44, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(45, new CreatureLevelData(45, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(46, new CreatureLevelData(46, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(47, new CreatureLevelData(47, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(48, new CreatureLevelData(48, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(49, new CreatureLevelData(49, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(50, new CreatureLevelData(50, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(51, new CreatureLevelData(51, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(52, new CreatureLevelData(52, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(53, new CreatureLevelData(53, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(54, new CreatureLevelData(54, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(55, new CreatureLevelData(55, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(56, new CreatureLevelData(56, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(57, new CreatureLevelData(57, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(58, new CreatureLevelData(58, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(59, new CreatureLevelData(59, "48*x*((19*x+3)+POW(1.5,x))", 27008));
root.Add(60, new CreatureLevelData(60, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(61, new CreatureLevelData(61, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(62, new CreatureLevelData(62, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(63, new CreatureLevelData(63, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(64, new CreatureLevelData(64, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(65, new CreatureLevelData(65, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(66, new CreatureLevelData(66, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(67, new CreatureLevelData(67, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(68, new CreatureLevelData(68, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(69, new CreatureLevelData(69, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(70, new CreatureLevelData(70, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(71, new CreatureLevelData(71, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(72, new CreatureLevelData(72, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(73, new CreatureLevelData(73, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(74, new CreatureLevelData(74, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(75, new CreatureLevelData(75, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(76, new CreatureLevelData(76, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(77, new CreatureLevelData(77, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(78, new CreatureLevelData(78, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(79, new CreatureLevelData(79, "48*x*((19*x+3)+POW(1.5,x))", 27009));
root.Add(80, new CreatureLevelData(80, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(81, new CreatureLevelData(81, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(82, new CreatureLevelData(82, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(83, new CreatureLevelData(83, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(84, new CreatureLevelData(84, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(85, new CreatureLevelData(85, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(86, new CreatureLevelData(86, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(87, new CreatureLevelData(87, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(88, new CreatureLevelData(88, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(89, new CreatureLevelData(89, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(90, new CreatureLevelData(90, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(91, new CreatureLevelData(91, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(92, new CreatureLevelData(92, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(93, new CreatureLevelData(93, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(94, new CreatureLevelData(94, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(95, new CreatureLevelData(95, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(96, new CreatureLevelData(96, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(97, new CreatureLevelData(97, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(98, new CreatureLevelData(98, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(99, new CreatureLevelData(99, "48*x*((19*x+3)+POW(1.5,x))", 27010));
root.Add(100, new CreatureLevelData(100, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(101, new CreatureLevelData(101, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(102, new CreatureLevelData(102, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(103, new CreatureLevelData(103, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(104, new CreatureLevelData(104, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(105, new CreatureLevelData(105, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(106, new CreatureLevelData(106, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(107, new CreatureLevelData(107, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(108, new CreatureLevelData(108, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(109, new CreatureLevelData(109, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(110, new CreatureLevelData(110, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(111, new CreatureLevelData(111, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(112, new CreatureLevelData(112, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(113, new CreatureLevelData(113, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(114, new CreatureLevelData(114, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(115, new CreatureLevelData(115, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(116, new CreatureLevelData(116, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(117, new CreatureLevelData(117, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(118, new CreatureLevelData(118, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(119, new CreatureLevelData(119, "48*x*((19*x+3)+POW(1.5,x))", 27011));
root.Add(120, new CreatureLevelData(120, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(121, new CreatureLevelData(121, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(122, new CreatureLevelData(122, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(123, new CreatureLevelData(123, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(124, new CreatureLevelData(124, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(125, new CreatureLevelData(125, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(126, new CreatureLevelData(126, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(127, new CreatureLevelData(127, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(128, new CreatureLevelData(128, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(129, new CreatureLevelData(129, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(130, new CreatureLevelData(130, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(131, new CreatureLevelData(131, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(132, new CreatureLevelData(132, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(133, new CreatureLevelData(133, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(134, new CreatureLevelData(134, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(135, new CreatureLevelData(135, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(136, new CreatureLevelData(136, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(137, new CreatureLevelData(137, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(138, new CreatureLevelData(138, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(139, new CreatureLevelData(139, "48*x*((19*x+3)+POW(1.5,x))", 27012));
root.Add(140, new CreatureLevelData(140, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(141, new CreatureLevelData(141, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(142, new CreatureLevelData(142, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(143, new CreatureLevelData(143, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(144, new CreatureLevelData(144, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(145, new CreatureLevelData(145, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(146, new CreatureLevelData(146, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(147, new CreatureLevelData(147, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(148, new CreatureLevelData(148, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(149, new CreatureLevelData(149, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(150, new CreatureLevelData(150, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(151, new CreatureLevelData(151, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(152, new CreatureLevelData(152, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(153, new CreatureLevelData(153, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(154, new CreatureLevelData(154, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(155, new CreatureLevelData(155, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(156, new CreatureLevelData(156, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(157, new CreatureLevelData(157, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(158, new CreatureLevelData(158, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(159, new CreatureLevelData(159, "48*x*((19*x+3)+POW(1.5,x))", 27013));
root.Add(160, new CreatureLevelData(160, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(161, new CreatureLevelData(161, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(162, new CreatureLevelData(162, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(163, new CreatureLevelData(163, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(164, new CreatureLevelData(164, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(165, new CreatureLevelData(165, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(166, new CreatureLevelData(166, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(167, new CreatureLevelData(167, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(168, new CreatureLevelData(168, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(169, new CreatureLevelData(169, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(170, new CreatureLevelData(170, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(171, new CreatureLevelData(171, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(172, new CreatureLevelData(172, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(173, new CreatureLevelData(173, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(174, new CreatureLevelData(174, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(175, new CreatureLevelData(175, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(176, new CreatureLevelData(176, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(177, new CreatureLevelData(177, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(178, new CreatureLevelData(178, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(179, new CreatureLevelData(179, "48*x*((19*x+3)+POW(1.5,x))", 27014));
root.Add(180, new CreatureLevelData(180, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(181, new CreatureLevelData(181, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(182, new CreatureLevelData(182, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(183, new CreatureLevelData(183, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(184, new CreatureLevelData(184, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(185, new CreatureLevelData(185, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(186, new CreatureLevelData(186, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(187, new CreatureLevelData(187, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(188, new CreatureLevelData(188, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(189, new CreatureLevelData(189, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(190, new CreatureLevelData(190, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(191, new CreatureLevelData(191, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(192, new CreatureLevelData(192, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(193, new CreatureLevelData(193, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(194, new CreatureLevelData(194, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(195, new CreatureLevelData(195, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(196, new CreatureLevelData(196, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(197, new CreatureLevelData(197, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(198, new CreatureLevelData(198, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(199, new CreatureLevelData(199, "48*x*((19*x+3)+POW(1.5,x))", 27015));
root.Add(200, new CreatureLevelData(200, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(201, new CreatureLevelData(201, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(202, new CreatureLevelData(202, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(203, new CreatureLevelData(203, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(204, new CreatureLevelData(204, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(205, new CreatureLevelData(205, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(206, new CreatureLevelData(206, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(207, new CreatureLevelData(207, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(208, new CreatureLevelData(208, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(209, new CreatureLevelData(209, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(210, new CreatureLevelData(210, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(211, new CreatureLevelData(211, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(212, new CreatureLevelData(212, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(213, new CreatureLevelData(213, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(214, new CreatureLevelData(214, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(215, new CreatureLevelData(215, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(216, new CreatureLevelData(216, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(217, new CreatureLevelData(217, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(218, new CreatureLevelData(218, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(219, new CreatureLevelData(219, "48*x*((19*x+3)+POW(1.5,x))", 27016));
root.Add(220, new CreatureLevelData(220, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(221, new CreatureLevelData(221, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(222, new CreatureLevelData(222, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(223, new CreatureLevelData(223, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(224, new CreatureLevelData(224, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(225, new CreatureLevelData(225, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(226, new CreatureLevelData(226, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(227, new CreatureLevelData(227, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(228, new CreatureLevelData(228, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(229, new CreatureLevelData(229, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(230, new CreatureLevelData(230, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(231, new CreatureLevelData(231, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(232, new CreatureLevelData(232, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(233, new CreatureLevelData(233, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(234, new CreatureLevelData(234, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(235, new CreatureLevelData(235, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(236, new CreatureLevelData(236, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(237, new CreatureLevelData(237, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(238, new CreatureLevelData(238, "48*x*((19*x+3)+POW(1.5,x))", 27017));
root.Add(239, new CreatureLevelData(239, "48*x*((19*x+3)+POW(1.5,x))", 27018));
}
public CreatureLevelData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CreatureLevelData;
Debug.LogError("在表格 CreatureLevelData中没有找到ID" + ID);
return null;}
}
public void WriteToFile(string path){}
public int GetCount(){
return root.Count;
}
public List<int> GetDataKeys(){
return new List<int>(root.Keys);
}
public Dictionary<string, string> GetReadDictionary(int key)
{Dictionary<string, string> pairs = new Dictionary<string, string>();
CreatureLevelData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CreatureLevelData GetData(int ID){
return CreatureLevelDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CreatureLevelDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CreatureLevelDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CreatureLevelDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CreatureLevelDataReader.Instance.WriteToFile(path);
}

}