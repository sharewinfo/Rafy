﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OEA.Library
{
    /// <summary>
    /// 路由事件
    /// </summary>
    public abstract partial class Entity
    {
        /// <summary>
        /// 发生某个路由事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnRoutedEvent(object sender, EntityRoutedEventArgs e)
        {
            this.Route(sender, e);
        }

        /// <summary>
        /// 触发某个路由事件
        /// </summary>
        /// <param name="indicator"></param>
        /// <param name="args"></param>
        protected void RaiseRoutedEvent(EntityRoutedEvent indicator, EventArgs args)
        {
            var arg = new EntityRoutedEventArgs
            {
                Source = this,
                Event = indicator,
                Args = args
            };

            this.Route(this, arg);
        }

        private void Route(object sender, EntityRoutedEventArgs e)
        {
            if (e.Handled) return;

            switch (e.Event.Type)
            {
                case EntityRoutedEventType.BubbleToParent:

                    var parent = this.GetParentEntity();
                    if (parent != null)
                    {
                        parent.OnRoutedEvent(sender, e);
                    }

                    break;
                case EntityRoutedEventType.BubbleToTreeParent:

                    if (this.TreeParentData != null)
                    {
                        this.TreeParentData.OnRoutedEvent(sender, e);
                    }

                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// ObjectView 路由事件的参数
    /// </summary>
    public class EntityRoutedEventArgs : EventArgs
    {
        internal EntityRoutedEventArgs() { }

        /// <summary>
        /// 事件源头的 ObjectView
        /// </summary>
        public Entity Source { get; internal set; }

        /// <summary>
        /// 发生的事件标记
        /// </summary>
        public EntityRoutedEvent Event { get; internal set; }

        /// <summary>
        /// 事件参数
        /// </summary>
        public EventArgs Args { get; internal set; }

        public bool Handled { get; set; }
    }

    /// <summary>
    /// Entity 路由事件的标记
    /// </summary>
    public class EntityRoutedEvent
    {
        private EntityRoutedEvent() { }

        public EntityRoutedEventType Type { get; private set; }

        public static EntityRoutedEvent Register(EntityRoutedEventType type)
        {
            return new EntityRoutedEvent()
            {
                Type = type
            };
        }
    }

    public enum EntityRoutedEventType
    {
        BubbleToParent,
        BubbleToTreeParent
    }
}