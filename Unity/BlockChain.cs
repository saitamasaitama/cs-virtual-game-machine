using System;
using System.Collections;
using System.Collections.Generic;

/**
 * this is not Unity script
 */
public class BlockChain<G>
    where G : SnapShot<G>
{
    public Block<G> Current;

    //永続ストレージからの読み込み
    public void sync(){
    }
}

public struct BlockChainMeta{
}

public abstract class Block<T>
  where T : SnapShot<T>
{
    public BlockMeta meta;
    public BlockChain<T> BlockChain;
    public abstract Diff<T> BlockDiff();
    public abstract SnapShot<T> CalcSnapShot();
    public abstract Block<T> AddTransaction(Transaction<T> t);
}

public struct BlockMeta
{
    public readonly int blockNumber;
    public readonly bool isUpdated;
}

public class Diff<T>
  where T : SnapShot<T>
{
    public List<Transaction<T>> transactions;   
}

public class Transaction<T>
  where T : SnapShot<T>
{
    
}


/// <summary>
/// シリアライズ化されたゲームデータを示す
/// </summary>
public class SnapShot<T> 
where T : SnapShot<T>
{   
    public Diff<T> SnapAndDiff()
    {
        //ブロックを更新する
 
        return null;
    }
    public Block<T> CreateNewBlock(){
      return null;
    }
}
