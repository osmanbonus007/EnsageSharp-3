﻿namespace Techies.Classes
{
    using System.Linq;

    using Ensage;
    using Ensage.Common.Extensions;

    using global::Techies.Utility;

    using SharpDX;

    /// <summary>
    ///     The land mine.
    /// </summary>
    internal class LandMine
    {
        #region Fields

        /// <summary>
        ///     The land mine entity.
        /// </summary>
        public Unit Entity;

        /// <summary>
        ///     The land mine handle.
        /// </summary>
        public float Handle;

        /// <summary>
        ///     The land mine ability level.
        /// </summary>
        public uint Level;

        /// <summary>
        ///     The land mine position.
        /// </summary>
        public Vector3 Position;

        /// <summary>
        ///     The land mine activation radius.
        /// </summary>
        public float Radius;

        /// <summary>
        ///     The land mine range display.
        /// </summary>
        public ParticleEffect RangeDisplay;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LandMine" /> class.
        /// </summary>
        /// <param name="entity">
        ///     The land mine entity.
        /// </param>
        public LandMine(Entity entity)
        {
            this.Handle = entity.Handle;

            this.Position = entity.Position;

            this.Level = Variables.LandMinesAbility.Level;

            this.Radius = Variables.LandMinesAbility.GetAbilityData("small_radius");
            this.Entity = entity as Unit;
            if (Variables.Stacks != null && !Variables.Stacks.Any(x => x.Position.Distance(this.Position) < 200))
            {
                Variables.Stacks.Add(new Stack(this.Position));
            }

            this.CreateRangeDisplay();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create range display.
        /// </summary>
        public void CreateRangeDisplay()
        {
            this.RangeDisplay = this.Entity.AddParticleEffect(@"particles\ui_mouseactions\drag_selected_ring.vpcf");
            this.RangeDisplay.SetControlPoint(1, new Vector3(255, 80, 80));
            this.RangeDisplay.SetControlPoint(3, new Vector3(9, 0, 0));
            this.RangeDisplay.SetControlPoint(2, new Vector3(this.Radius + 30, 255, 0));
        }

        /// <summary>
        ///     The delete.
        /// </summary>
        public void Delete()
        {
            this.RangeDisplay.Dispose();
            Variables.LandMines.Remove(this);
        }

        /// <summary>
        ///     The distance.
        /// </summary>
        /// <param name="v">
        ///     The v.
        /// </param>
        /// <returns>
        ///     The <see cref="float" />.
        /// </returns>
        public float Distance(Vector3 v)
        {
            return this.Position.Distance(v);
        }

        #endregion
    }
}