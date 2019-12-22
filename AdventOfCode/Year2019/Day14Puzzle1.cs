using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Day 14: Space Stoichiometry ---
    /// 
    /// As you approach the rings of Saturn, your ship's low fuel indicator turns 
    /// on. There isn't any fuel here, but the rings have plenty of raw material. 
    /// Perhaps your ship's Inter-Stellar Refinery Union brand nanofactory can 
    /// turn these raw materials into fuel.
    /// 
    /// You ask the nanofactory to produce a list of the reactions it can perform 
    /// that are relevant to this process (your puzzle input). Every reaction turns 
    /// some quantities of specific input chemicals into some quantity of an 
    /// output chemical. Almost every chemical is produced by exactly one reaction; 
    /// the only exception, ORE, is the raw material input to the entire process 
    /// and is not produced by a reaction.
    /// 
    /// You just need to know how much ORE you'll need to collect before you can 
    /// produce one unit of FUEL.
    /// 
    /// Each reaction gives specific quantities for its inputs and output; 
    /// reactions cannot be partially run, so only whole integer multiples of these 
    /// quantities can be used. (It's okay to have leftover chemicals when you're 
    /// done, though.) For example, the reaction 1 A, 2 B, 3 C => 2 D means that 
    /// exactly 2 units of chemical D can be produced by consuming exactly 1 A, 2 
    /// B and 3 C. You can run the full reaction as many times as necessary; 
    /// for example, you could produce 10 D by consuming 5 A, 10 B, and 15 C.
    /// 
    /// Suppose your nanofactory produces the following list of reactions:
    /// 10 ORE => 10 A
    /// 1 ORE => 1 B
    /// 7 A, 1 B => 1 C
    /// 7 A, 1 C => 1 D
    /// 7 A, 1 D => 1 E
    /// 7 A, 1 E => 1 FUEL
    /// 
    /// The first two reactions use only ORE as inputs; they indicate that you can 
    /// produce as much of chemical A as you want (in increments of 10 units, each 
    /// 10 costing 10 ORE) and as much of chemical B as you want (each costing 1 
    /// ORE). To produce 1 FUEL, a total of 31 ORE is required: 1 ORE to produce 1 
    /// B, then 30 more ORE to produce the 7 + 7 + 7 + 7 = 28 A (with 2 extra A w
    /// asted) required in the reactions to convert the B into C, C into D, D 
    /// into E, and finally E into FUEL. (30 A is produced because its reaction 
    /// requires that it is created in increments of 10.)
    /// 
    /// Or, suppose you have the following list of reactions:
    /// 9 ORE => 2 A
    /// 8 ORE => 3 B
    /// 7 ORE => 5 C
    /// 3 A, 4 B => 1 AB
    /// 5 B, 7 C => 1 BC
    /// 4 C, 1 A => 1 CA
    /// 2 AB, 3 BC, 4 CA => 1 FUEL
    /// 
    /// The above list of reactions requires 165 ORE to produce 1 FUEL:
    /// * Consume 45 ORE to produce 10 A.
    /// * Consume 64 ORE to produce 24 B.
    /// * Consume 56 ORE to produce 40 C.
    /// * Consume 6 A, 8 B to produce 2 AB.
    /// * Consume 15 B, 21 C to produce 3 BC.
    /// * Consume 16 C, 4 A to produce 4 CA.
    /// * Consume 2 AB, 3 BC, 4 CA to produce 1 FUEL.
    /// 
    /// Here are some larger examples:
    /// * 13312 ORE for 1 FUEL:
    ///   157 ORE => 5 NZVS
    ///   165 ORE => 6 DCFZ
    ///   44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL
    ///   12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ
    ///   179 ORE => 7 PSHF
    ///   177 ORE => 5 HKGWZ
    ///   7 DCFZ, 7 PSHF => 2 XJWVT
    ///   165 ORE => 2 GPVTF
    ///   3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT
    /// 
    /// * 180697 ORE for 1 FUEL:
    ///   2 VPVL, 7 FWMGM, 2 CXFTF, 11 MNCFX => 1 STKFG
    ///   17 NVRVD, 3 JNWZP => 8 VPVL
    ///   53 STKFG, 6 MNCFX, 46 VJHF, 81 HVMC, 68 CXFTF, 25 GNMV => 1 FUEL
    ///   22 VJHF, 37 MNCFX => 5 FWMGM
    ///   139 ORE => 4 NVRVD
    ///   144 ORE => 7 JNWZP
    ///   5 MNCFX, 7 RFSQX, 2 FWMGM, 2 VPVL, 19 CXFTF => 3 HVMC
    ///   5 VJHF, 7 MNCFX, 9 VPVL, 37 CXFTF => 6 GNMV
    ///   145 ORE => 6 MNCFX
    ///   1 NVRVD => 8 CXFTF
    ///   1 VJHF, 6 MNCFX => 4 RFSQX
    ///   176 ORE => 6 VJHF
    /// 
    /// * 2210736 ORE for 1 FUEL:
    ///   171 ORE => 8 CNZTR
    ///   7 ZLQW, 3 BMBT, 9 XCVML, 26 XMNCP, 1 WPTQ, 2 MZWV, 1 RJRHP => 4 PLWSL
    ///   114 ORE => 4 BHXH
    ///   14 VRPVC => 6 BMBT
    ///   6 BHXH, 18 KTJDG, 12 WPTQ, 7 PLWSL, 31 FHTLT, 37 ZDVW => 1 FUEL
    ///   6 WPTQ, 2 BMBT, 8 ZLQW, 18 KTJDG, 1 XMNCP, 6 MZWV, 1 RJRHP => 6 FHTLT
    ///   15 XDBXC, 2 LTCX, 1 VRPVC => 6 ZLQW
    ///   13 WPTQ, 10 LTCX, 3 RJRHP, 14 XMNCP, 2 MZWV, 1 ZLQW => 1 ZDVW
    ///   5 BMBT => 4 WPTQ
    ///   189 ORE => 9 KTJDG
    ///   1 MZWV, 17 XDBXC, 3 XCVML => 2 XMNCP
    ///   12 VRPVC, 27 CNZTR => 2 XDBXC
    ///   15 KTJDG, 12 BHXH => 5 XCVML
    ///   3 BHXH, 2 VRPVC => 7 MZWV
    ///   121 ORE => 7 VRPVC
    ///   7 XCVML => 6 RJRHP
    ///   5 BHXH, 4 VRPVC => 5 LTCX
    /// 
    /// Given the list of reactions in your puzzle input, what is the minimum 
    /// amount of ORE required to produce exactly 1 FUEL?
    /// </summary>
    public class Day14Puzzle1 : IPuzzle
    {
        public void Solve() => throw new NotImplementedException();

        public const string input = @"4 NZGF => 6 WBMZG
20 FWMN, 2 QTMF, 5 FMVDV, 1 CVBPJ, 2 KVJK, 20 XSTBX, 7 NBFS => 5 SHPSF
7 LVQM => 5 NXDHX
1 FNDMP, 1 QZJV, 12 RMTG => 7 JBFW
10 GKVF, 1 NXDHX => 8 NZGF
12 QZJV => 8 RSMC
8 RWTD => 7 NBFS
4 CZGXS, 25 QTMF, 2 PHFQB => 3 BWQN
3 WQZD => 9 CTZKV
2 DCTQ, 18 CTZKV => 4 QLHZW
31 QLHZW, 11 FNDMP => 6 WFDXN
8 RLQC => 2 ZPJS
2 SWSQG, 13 CVBPJ => 9 DWCND
7 PBXB, 6 HKSWM, 4 BDPC, 4 KVJK, 2 ZLGKH, 9 LXFG, 1 ZPJS => 4 SWCWH
6 QZJV => 7 RLQC
3 QZJV, 11 MRQHX, 15 GKVF => 4 FMVDV
3 NXDHX, 1 GKNQL => 3 VMDS
1 VMDS => 2 RHSQ
13 GKNQL, 4 NXDHX, 2 GKVF => 8 MRQHX
4 PVRN => 2 WBSL
2 CVBPJ => 9 PVRN
3 FNDMP => 9 BZKC
180 ORE => 6 FWMN
13 DCTQ, 2 RHSQ => 5 CVBPJ
1 DWCND, 12 BZKC, 2 WBRBV => 6 HTLZ
1 LMGL, 11 XDVL, 7 DWCND => 5 ZLGKH
3 FMFTD => 3 HKSWM
1 FNDMP, 5 RMTG, 3 QLHZW => 9 CZGXS
7 DCTQ => 3 FNDMP
1 SHPSF, 2 SWCWH, 40 WFDXN, 67 WBMZG, 53 WBSL, 2 CQJDJ, 41 BWQN, 12 GMQVW, 48 PDRJ, 42 RSMC => 1 FUEL
3 VMDS, 1 BHRZ => 9 DCTQ
22 DCTQ, 4 NZGF => 7 RMTG
29 RWTD, 3 FMFTD => 5 LMGL
12 WBRBV, 13 PDRJ, 36 RSRG => 4 LXFG
1 SWSQG, 2 NLPB => 3 WBRBV
7 HTKLM, 8 CTZKV => 2 RWTD
4 BQXL, 1 FWMN => 9 GKNQL
4 WFDXN => 9 HTKLM
2 XDVL => 5 QTMF
1 PHFQB, 21 LMGL, 2 SWSQG => 7 GMQVW
23 CZGXS, 11 FMVDV => 3 PDRJ
1 DWCND, 1 NPMXR, 1 RSRG, 1 JBFW, 12 VXWKZ, 9 KVJK => 4 CQJDJ
106 ORE => 4 BQXL
4 PHFQB => 8 NPMXR
1 GKNQL => 8 WQZD
6 BDPC => 2 PHFQB
1 DWCND => 7 PBXB
1 RSMC, 1 PDRJ => 8 SWSQG
1 LVQM => 4 BHRZ
7 CVBPJ, 1 SWSQG, 1 NLPB => 2 VXWKZ
1 BHRZ, 1 JBFW => 6 XDVL
12 LMGL, 8 RWTD => 4 XSTBX
4 RSMC => 6 BDPC
1 BHRZ, 5 NXDHX => 3 GKVF
6 FMVDV, 6 VXWKZ, 37 CVBPJ => 5 KVJK
7 NLPB, 3 HTLZ => 4 RSRG
1 PDRJ => 1 FMFTD
6 RHSQ, 1 NZGF => 5 QZJV
127 ORE => 3 LVQM
3 RHSQ, 2 RLQC, 1 WFDXN => 1 NLPB";
    }
}
