﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    // アスペクト情報管理クラス
    // ポジションリストにぶら下がる
    public enum AspectKind
    {
        CONJUNCTION = 1,
        OPPOSITION = 2, // 180 2
        INCONJUNCT = 3,
        SESQUIQUADRATE = 4,
        TRINE = 5, // 3
        SQUARE = 6, // 4
        SEXTILE = 7, // 60 6
        SEMISEXTILE = 8, // 30 12
        SEMIQINTILE = 9, // 36 10
        NOVILE = 10, // 40 9
        SEMISQUARE = 11, // 45 8
        SEPTILE = 12, // 51.42 7
        QUINTILE = 13, // 72 5
        BIQUINTILE = 14 // 144 2.5
    };

    public enum AspectDegrees
    {
        OPPOSITION = 180,
        INCONJUNCT = 150,
        SESQUIQUADRATE = 135,
        TRINE = 120,
        SQUARE = 90,
        SEXTILE = 60,
        SEMISEXTILE = 30,
        SEMIQUINTILE = 36,
        NOVILE = 40,
        SEMISQUARE = 45,
        SEPTILE = 51,
        QUINTILE = 72,
        BIQUINTILE = 144,
    }

    public enum SoftHard
    {
        SOFT = 1,
        HARD = 2
    }
    public class AspectInfo
    {
        public double targetPosition; // 絶対位置
        public AspectKind aspectKind; // アスペクト種別
        public SoftHard softHard; // ソフトorハード 1:soft, 2:hard
        public int srcPlanetNo; // 自分の番号
        public int targetPlanetNo; // ターゲット番号
        public bool isDisp; // 表示するかどうか
        public double absoluteDegree; // degree
        public double targetDegree;
    }
}
