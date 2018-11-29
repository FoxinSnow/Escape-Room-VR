//https://github.com/SaiTingHu/MeshMelt/blob/master/Script/MeshMelt.cs

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 网格融化器
/// </summary>
#region 前缀
[AddComponentMenu("模型网格融化器")]
#endregion
public class MeshMelt : MonoBehaviour
{

    #region 变量
    //目标融化方向
    public MeltDirection _MeltDirection = MeltDirection.y;
    //目标融化速度
    public float _MeltSpeed = 1;

    //目标融化体
    private GameObject _Target;
    //目标融化Mesh
    private Mesh _Mesh;
    //目标所有顶点集合
    private Vector3[] _AllVertex;
    //目标融化至低点
    private Vector3 _DissolutionMinPoint;
    //目标融化至高点
    private Vector3 _DissolutionMaxPoint;

    //目标是否允许融化
    private bool IsCanMelt = true;
    //目标开始融化
    private bool IsStartMelt = false;
    #endregion

    #region 函数
    void Start()
    {
        BeginMelt();
        Init();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    void Init()
    {
        _Target = this.gameObject;
        if (_Target.GetComponent<MeshFilter>() == null)
        {
            Debug.LogError("游戏物体缺少组件 MeshFilter！");
            return;
        }
        if (_Target.GetComponent<MeshRenderer>() == null)
        {
            Debug.LogError("游戏物体缺少组件 MeshRenderer！");
            return;
        }
        if (_MeltSpeed < 0)
        {
            Debug.LogError("融化速度异常！");
            return;
        }
        //获取目标网格
        _Mesh = _Target.GetComponent<MeshFilter>().mesh;
        //获取目标所有顶点
        _AllVertex = _Mesh.vertices;
        //记录目标融化至高点及至低点
        _DissolutionMaxPoint = _DissolutionMinPoint = _AllVertex[0];
        //获取目标融化至高点及至低点
        for (int i = 0; i < _AllVertex.Length; i++)
        {
            if (_MeltDirection == MeltDirection.x)
            {
                if (_AllVertex[i].x < _DissolutionMinPoint.x)
                    _DissolutionMinPoint = _AllVertex[i];
                else if (_AllVertex[i].x > _DissolutionMaxPoint.x)
                    _DissolutionMaxPoint = _AllVertex[i];
            }
            else if (_MeltDirection == MeltDirection.y)
            {
                if (_AllVertex[i].y < _DissolutionMinPoint.y)
                    _DissolutionMinPoint = _AllVertex[i];
                else if (_AllVertex[i].y > _DissolutionMaxPoint.y)
                    _DissolutionMaxPoint = _AllVertex[i];
            }
            else if (_MeltDirection == MeltDirection.z)
            {
                if (_AllVertex[i].z < _DissolutionMinPoint.z)
                    _DissolutionMinPoint = _AllVertex[i];
                else if (_AllVertex[i].z > _DissolutionMaxPoint.z)
                    _DissolutionMaxPoint = _AllVertex[i];
            }
        }
        IsCanMelt = true;
    }
    void Update()
    {
        if (IsStartMelt)
        {
            #region X轴融化
            if (_MeltDirection == MeltDirection.x && _DissolutionMaxPoint.x > _DissolutionMinPoint.x)
            {
                for (int i = 0; i < _AllVertex.Length; i++)
                {
                    //目标纵向融化
                    if (_AllVertex[i].x > _DissolutionMinPoint.x)
                    {
                        _AllVertex[i] = new Vector3(_AllVertex[i].x - Time.deltaTime * _MeltSpeed, _AllVertex[i].y, _AllVertex[i].z);
                    }
                    if (_AllVertex[i].x < _DissolutionMinPoint.x)
                    {
                        _AllVertex[i] = new Vector3(_DissolutionMinPoint.x, _AllVertex[i].y, _AllVertex[i].z);
                    }
                    //目标扩散融化
                    if (_AllVertex[i].x.Equals(_DissolutionMinPoint.x))
                    {
                        _AllVertex[i] += _Mesh.normals[i] * Time.deltaTime * _MeltSpeed;
                    }
                }
                //刷新目标网格
                _Mesh.vertices = _AllVertex;
                _Target.GetComponent<MeshFilter>().mesh = _Mesh;
                //重新记录至高点
                _DissolutionMaxPoint = new Vector3(_DissolutionMaxPoint.x - Time.deltaTime * _MeltSpeed
                    , _DissolutionMaxPoint.y, _DissolutionMaxPoint.z);
            }
            else if (_MeltDirection == MeltDirection.x && _DissolutionMaxPoint.x < _DissolutionMinPoint.x)
            {
                IsStartMelt = false;
                EndMelt();
            }
            #endregion

            #region Y轴融化
            if (_MeltDirection == MeltDirection.y && _DissolutionMaxPoint.y > _DissolutionMinPoint.y)
            {
                for (int i = 0; i < _AllVertex.Length; i++)
                {
                    //目标纵向融化
                    if (_AllVertex[i].y > _DissolutionMinPoint.y)
                    {
                        _AllVertex[i] = new Vector3(_AllVertex[i].x, _AllVertex[i].y - Time.deltaTime * _MeltSpeed, _AllVertex[i].z);
                    }
                    if (_AllVertex[i].y < _DissolutionMinPoint.y)
                    {
                        _AllVertex[i] = new Vector3(_AllVertex[i].x, _DissolutionMinPoint.y, _AllVertex[i].z);
                    }
                    //目标扩散融化
                    if (_AllVertex[i].y.Equals(_DissolutionMinPoint.y))
                    {
                        _AllVertex[i] += _Mesh.normals[i] * Time.deltaTime * _MeltSpeed;
                    }
                }
                //刷新目标网格
                _Mesh.vertices = _AllVertex;
                _Target.GetComponent<MeshFilter>().mesh = _Mesh;
                //重新记录至高点
                _DissolutionMaxPoint = new Vector3(_DissolutionMaxPoint.x
                    , _DissolutionMaxPoint.y - Time.deltaTime * _MeltSpeed, _DissolutionMaxPoint.z);
            }
            else if (_MeltDirection == MeltDirection.y && _DissolutionMaxPoint.y < _DissolutionMinPoint.y)
            {
                IsStartMelt = false;
                EndMelt();
            }
            #endregion

            #region Z轴融化
            if (_MeltDirection == MeltDirection.z && _DissolutionMaxPoint.z > _DissolutionMinPoint.z)
            {
                for (int i = 0; i < _AllVertex.Length; i++)
                {
                    //目标纵向融化
                    if (_AllVertex[i].z > _DissolutionMinPoint.z)
                    {
                        _AllVertex[i] = new Vector3(_AllVertex[i].x, _AllVertex[i].y, _AllVertex[i].z - Time.deltaTime * _MeltSpeed);
                    }
                    if (_AllVertex[i].z < _DissolutionMinPoint.z)
                    {
                        _AllVertex[i] = new Vector3(_AllVertex[i].x, _AllVertex[i].y, _DissolutionMinPoint.z);
                    }
                    //目标扩散融化
                    if (_AllVertex[i].z.Equals(_DissolutionMinPoint.z))
                    {
                        _AllVertex[i] += _Mesh.normals[i] * Time.deltaTime * _MeltSpeed;
                    }
                }
                //刷新目标网格
                _Mesh.vertices = _AllVertex;
                _Target.GetComponent<MeshFilter>().mesh = _Mesh;
                //重新记录至高点
                _DissolutionMaxPoint = new Vector3(_DissolutionMaxPoint.x
                    , _DissolutionMaxPoint.y, _DissolutionMaxPoint.z - Time.deltaTime * _MeltSpeed);
            }
            else if (_MeltDirection == MeltDirection.z && _DissolutionMaxPoint.z < _DissolutionMinPoint.z)
            {
                IsStartMelt = false;
                EndMelt();
            }
            #endregion
        }
    }
    /// <summary>
    /// 融化结束
    /// </summary>
    void EndMelt()
    {
        Destroy(this);
    }
    #endregion

    #region 控制开关
    /// <summary>
    /// 开始融化
    /// </summary>
    public void BeginMelt()
    {
        if (IsCanMelt)
        {
            IsStartMelt = true;
            IsCanMelt = false;
            transform.GetComponent<Collider>().enabled = false;
        }
        else
            Debug.Log("由于未知原因，目标无法融化或处于融化中！");
    }
    #endregion
}

#region 枚举
//融化方向
public enum MeltDirection
{
    x = 0,
    y = 1,
    z = 2
}
#endregion