/*----------------------------------------------------------------
// Copyright (C) 2012 ����δ�� ��Ȩ���С� 
//
// �ļ�����DataProviderAction.cs
// �ļ������������޸ġ�������ɾ�� ö��
// 
// ������ʶ��2012��6��12�� 13:38:22 ����
// �޸ı�ʶ��
// �޸�������
//
// �޸ı�ʶ��
// �޸�������
//----------------------------------------------------------------*/


namespace YSWL.MALL.Model.Shop.Products
{
    public enum DataProviderAction
    {
        None = -1,
        Create = 0,
        Update = 1,
        Delete = 2
    }

    /// <summary>
    /// -1:δ��� 0:�¼�  1:�ϼ� 2:��ɾ��
    /// </summary>
    public enum ProductSaleStatus
    {
        //DONE: ��Ʒ״̬����Ϊ 0:�¼�(�ֿ���)  1:�ϼ� 2:��ɾ�� <BEN ADD 2012-06-29>
        UnCheck = -1,
        InStock = 0,
        OnSale = 1,
        Deleted = 2
    }


    /// <summary>
    /// 0:�����з���  -1:�޷���
    /// </summary>
    public enum ProductCategoryStatus
    {
        None = -1,
        Normal = 0
    }

    /// <summary>
    ///  0:��ѡ  1����ѡ   2���Զ�������  3�����
    /// </summary>
    public enum ProductAttributeModel
    {
        None = -1,
        One = 0,
        Any = 1,
        Input = 2,
        Specification = 3
    }

    /// <summary>
    /// ��ѯ��ʽ 0 ������ 1�����
    /// </summary>
    public enum SearchType
    {
        None = -1,
        ExtAttribute = 0,
        Specification = 1
    }

    /// <summary>
    /// ����ʽ 0���� 1������
    /// </summary>
    public enum SwapSequenceIndex
    {
        None = -1,
        Down = 0,
        Up = 1
    }

    /// <summary>
    /// ��Ʒ״̬ 0���Ƽ� 1���� 2�ؼ� 3������,4:��ҳ�Ƽ�
    /// </summary>
    public enum ProductRecType
    {
        None = -1,
        Recommend = 0,
        Hot = 1,
        Cheap = 2,
        Latest = 3,
        IndexRec = 4
    }

 
}