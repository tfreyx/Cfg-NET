﻿using System;
using System.Collections.Generic;
using Cfg.Net;
using NUnit.Framework;

namespace Cfg.Test {

    [TestFixture]
    public class Parameters {

        [Test]
        public void TestXml() {
            var xml = @"
    <cfg>
        <environments default='two'>
            <add name='one'>
                <parameters>
                    <add name='p1' value='one-1' />
                    <add name='p2' value='one-2' />
                </parameters>
            </add>
            <add name='two'>
                <parameters>
                    <add name='p1' value='two-1' />
                    <add name='p2' value='two-2' />
                </parameters>
            </add>
        </environments>
        <things>
            <add name='thing-1' value='@(p1)' />
            <add name='thing-2' value='@(p2)' />
        </things>
    </cfg>
".Replace("'", "\"");

            var parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"p1", "i am the new p1"}
            };

            var cfg = new MyCfg(xml, parameters);

            foreach (var problem in cfg.Errors()) {
                Console.WriteLine(problem);
            }

            Assert.AreEqual(0, cfg.Errors().Length);

            Assert.AreEqual(2, cfg.Environments.Count);
            Assert.AreEqual(false, cfg.Environments[0].Default == cfg.Environments[0].Name);
            Assert.AreEqual(true, cfg.Environments[1].Default == cfg.Environments[1].Name);

            Assert.AreEqual("i am the new p1", cfg.Things[0].Value, "I should be passed in for p1.");
            Assert.AreEqual("two-2", cfg.Things[1].Value, "I am the default value for p2 in the default environment two.");

        }


        [Test]
        public void TestJson() {
            var json = @"
    {
        'environments': [ {
                'name':'one',
                'parameters':[
                    { 'name':'p1', 'value':'one-1' }
                    { 'name':'p2', 'value':'one-2' }
                ]
            },
            {
                'name':'two',
                'default':'two',
                'parameters':[
                    { 'name':'p1', 'value':'two-1' }
                    { 'name':'p2', 'value':'two-2' }
                ]
            }
        ],
        'environments.default':'two',
        'things':[
            { 'name':'thing-1', 'value':'@(p1)' }
            { 'name':'thing-2', 'value':'@(p2)' }
        ]
    }
".Replace("'", "\"");

            var parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {"p1", "i am the new p1"}
            };

            var cfg = new MyCfg(json, parameters);

            foreach (var problem in cfg.Errors()) {
                Console.WriteLine(problem);
            }

            Assert.AreEqual(0, cfg.Errors().Length);

            Assert.AreEqual(2, cfg.Environments.Count);
            Assert.AreEqual(false, cfg.Environments[0].Default == cfg.Environments[0].Name);
            Assert.AreEqual(true, cfg.Environments[1].Default == cfg.Environments[1].Name);

            Assert.AreEqual("i am the new p1", cfg.Things[0].Value, "I should be passed in for p1.");
            Assert.AreEqual("two-2", cfg.Things[1].Value, "I am the default value for p2 in the default environment two.");

        }

    }

    public class MyCfg : CfgNode {
        public MyCfg(string xml, Dictionary<string, string> parameters = null) {
            this.Load(xml, parameters);
        }

        [Cfg(required = false, sharedProperty = "default", sharedValue = "")]
        public List<MyEnvironment> Environments { get; set; }

        [Cfg(required = true)]
        public List<MyThing> Things { get; set; }
    }

    public class MyThing : CfgNode {

        [Cfg(required = true, unique = true)]
        public string Name { get; set; }

        [Cfg(required = true)]
        public string Value { get; set; }
    }

    public class MyEnvironment : CfgNode {

        [Cfg(required = true)]
        public string Name { get; set; }

        [Cfg(required = true)]
        public List<MyParameter> Parameters { get; set; }

        [Cfg()] //shared property, defined in parent
        public string Default { get; set; }
    }

    public class MyParameter : CfgNode {
        [Cfg(required = true, unique = true)]
        public string Name { get; set; }
        [Cfg(required = true)]
        public string Value { get; set; }
    }
}
