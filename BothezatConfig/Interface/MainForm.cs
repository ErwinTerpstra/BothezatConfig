﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BothezatConfig.Interface
{
    public partial class MainForm : Form
    {
        #region Cube information

        private float[] cubeColors = 
        {
			1.0f, 0.0f, 0.0f, 1.0f,
			0.0f, 1.0f, 0.0f, 1.0f,
			0.0f, 0.0f, 1.0f, 1.0f,
			0.0f, 1.0f, 1.0f, 1.0f,
			1.0f, 0.0f, 0.0f, 1.0f,
			0.0f, 1.0f, 0.0f, 1.0f,
			0.0f, 0.0f, 1.0f, 1.0f,
			0.0f, 1.0f, 1.0f, 1.0f,
		};

        private byte[] cubeIndices =
		{
			1, 0, 2, // front
			3, 2, 0,
			6, 4, 5, // back
			4, 6, 7,
			4, 7, 0, // left
			7, 3, 0,
			1, 2, 5, //right
			2, 6, 5,
			0, 1, 5, // top
			0, 5, 4,
			2, 3, 6, // bottom
			3, 7, 6,
		};

        private float[] cubeVertices =
        {
			-0.5f,  0.5f,  0.5f, // vertex[0]
			 0.5f,  0.5f,  0.5f, // vertex[1]
			 0.5f, -0.5f,  0.5f, // vertex[2]
			-0.5f, -0.5f,  0.5f, // vertex[3]
			-0.5f,  0.5f, -0.5f, // vertex[4]
			 0.5f,  0.5f, -0.5f, // vertex[5]
			 0.5f, -0.5f, -0.5f, // vertex[6]
			-0.5f, -0.5f, -0.5f, // vertex[7]
		};

        #endregion

        private bool glLoaded;

        private Quaternion orientation;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            orientation = Quaternion.Identity;
        }


        public void AddConsoleOutput(string contents)
        {
            contents = contents.Replace("\n", "\r\n");

            consoleOutputBox.Suspend();
            consoleOutputBox.AppendText(contents);
            consoleOutputBox.Resume();
        }

        public void SetOrientation(Quaternion orientation)
        {
            this.orientation = orientation;

            glControl.Invalidate();
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            glLoaded = true;

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            glControl_Resize(sender, e);
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            if (!glLoaded)
                return;

            int w = glControl.Width;
            int h = glControl.Height;

            Matrix4 matrixProjection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1f, 100f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref matrixProjection);

            GL.Viewport(0, 0, w, h);
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!glLoaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            Matrix4 view = Matrix4.LookAt(0f, 0f, -5f, 0f, 0f, 0f, 0f, 1f, 0f);
            Matrix4 model = Matrix4.CreateFromQuaternion(orientation);

            Matrix4 modelView = model * view;

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelView);
            
            GL.VertexPointer(3, VertexPointerType.Float, 0, cubeVertices);
            GL.ColorPointer(4, ColorPointerType.Float, 0, cubeColors);
            GL.DrawElements(PrimitiveType.Triangles, 36, DrawElementsType.UnsignedByte, cubeIndices);
              
            glControl.SwapBuffers();
        }
    }
}