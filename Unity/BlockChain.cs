using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * this is not Unity script
 */
public class BlockChain<GAMEDATA>
    where GAMEDATA : SnapShot
{
    public Block Current;

}

public abstract class Block
{
    public BlockMeta meta;

    public BlockChain<T> BlockChain;

    public abstract Diff BlockDiff();
    public abstract SnapShot CalcSnapShot();
    
    
    
}

public struct BlockMeta
{
    public readonly int blockNumber;
    public readonly bool isUpdated;


}

public class Diff
{
    public List<Transaction> transactions;
    
}

public class Transaction
{
    
}


/// <summary>
/// シリアライズ化されたゲームデータを示す
/// </summary>
public class SnapShot
{
    
    
    public Diff SnapAndDiff()
    {
        //ブロックを更新する
        
        return null;
    }
}