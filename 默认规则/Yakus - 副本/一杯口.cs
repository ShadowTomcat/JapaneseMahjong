﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日本麻将.Yakus {
	public sealed class 一杯口 : Yaku {
		public override int OrderIndex => 9;

		public override YakuType Type => YakuType.None;

		protected internal override bool FilterTest(int junkoCount, int pungCount) {
			return junkoCount >= 2;
		}

		protected internal override bool FilterTest(int[] kindCountsFromTiles, int[] kindCounts, int[] kindCountsWithoutPair) {
			return kindCountsWithoutPair[0] >= 2 || kindCountsWithoutPair[1] >= 2 || kindCountsWithoutPair[2] >= 2;
		}

		protected internal override bool Test(ICollection<YakuValue> result, Tile[] tiles, IGroups groups, YakuEnvironment env) {
			if ((env & YakuEnvironment.门前清) == 0) return false;
			int[,] counts = new int[3, 7];
			foreach (var g in groups.JunkoList) {
				counts[g.Key.SortedLevel, (g.Key as NumberTile).Number - 1]++;
			}
			bool yes = false;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 7; j++) {
					if (counts[i, j] == 2) {
						yes = !yes; // 防止二杯口
					}
				}

			if (!yes) return false;
			result.Add(YakuValue.FromFanValue("一杯口", 1));
			return true;
		}
	}
}
