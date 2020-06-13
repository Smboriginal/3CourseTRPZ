﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{
    /// <summary>
    /// Обобщенный создатель.
    /// Интерфейс/абстрактный класс, которые определяет сигнатуру фабричного метода
    /// для создание приложух(продуктов).
    /// Для всех создателей этот общий класс только один!!!
    /// К примеру, MessageBase(IMessanger) который определяет интерфейс создания смс
    /// , но реализацию логики передает наследующим классам. 
    /// </summary>
    public abstract class Creator
    {
        /// <summary>
        /// Фабричный метод определяющий сигнатуру метода создания продукта.
        /// Также может содержать реализацию по уиолчанию (для классов).
        /// </summary>
        /// <returns> Обобщенный продукт. </returns>
        public abstract IProduct FactoryMethod();

    }

    /// <summary>
    /// Конкретный создатель.
    /// Это класс конкретного создателя определенного продукта, реализующий фабричный метод.
    /// У каждого продукта должен быть свой создатель, конкретных создателей может быть много.
    /// Я создал один конкретный мессенджер : TelegramMessenger.
    /// </summary>


    public class ConcreteCreator : Creator
    {
        /// <summary>
        /// Конкретная реализация фабричного метода.
        /// Определяет процесс создания определенного продукта,
        /// вовращает - обобщенный продукт (абстрактный класс или интерфейс продукта).
        /// Делается это для того, чтобы обобщенный создатель не зависел от конкретных реализаций продукта
        /// и создателя продукта!!
        /// </summary>
        /// <returns>Конкретный продукт.</returns>

        public override IProduct FactoryMethod()
        {
            /// тут могут быть ваши действия
            return new ConcreteProduct();
        }
    }

    /// <summary>
    /// Обобщенный продукт.
    /// Интерфейс или абстрактный класс, используемый для определения общих для всех продуктов свойства и методы
    /// Этот класс (или интерфейс) один и является общим для всех конкретных продуктов.

    /// Я сделал MessageBase (IMessage), определяющий поля и методы для отправки смс.
    /// </summary>


    public interface IProduct
    {
        string Name { get; set; }
        void DoWork();
    }

    /// <summary>
    /// Конкретный продукт.
    /// Класс, который определяет поведение определённого продукта.
    /// Но для каждого конкретного продукта необходим конкретный создатель,
    /// таковых может быть бесчисленное кол-во.
    /// Мною были реализованы TestMessage & TelegramMessage.
    /// </summary>

    public class ConcreteProduct : IProduct
    {
        public string Name { get; set; }
        public void DoWork() { }
    }
}
