using UnityEngine;
using System.Collections;

public class Pair<t1, t2>{
    private t1 blackjack;
    private t2 hookers;

    public Pair(t1 left, t2 right)
    {
        this.blackjack  = left;
        this.hookers    = right;
    }

    public t1 getLeft()
    {
        return blackjack;
    }

    public t2 getRight()
    {
        return hookers;
    }

    public void setLeft(t1 obj)
    {
        this.blackjack = obj;
    }
    public void setRight(t2 obj)
    {
        this.hookers = obj;
    }
}
