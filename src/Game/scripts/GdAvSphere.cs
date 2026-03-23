using System;
using Godot;

// ReSharper disable once CheckNamespace
namespace Game;

public partial class GdAvSphere : MeshInstance3D
{
	private const float PivotDistance = 6.0f;
	private const float PivotRotationSpeed = MathF.PI / 4.0f;

	private const float SelfRotationSpeed = MathF.PI;
	private readonly Vector3 _pivot = Vector3.Zero;
	private float _pivotAngle;
	private float _selfAngle;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_pivotAngle += (float)(delta * PivotRotationSpeed);
		GlobalPosition = _pivot + new Vector3(MathF.Cos(_pivotAngle), 0.0f, MathF.Sin(_pivotAngle)) * PivotDistance;

		_selfAngle += (float)(delta * SelfRotationSpeed);
		Rotation = new Vector3(0.0f, _selfAngle, 0.0f);
	}
}
