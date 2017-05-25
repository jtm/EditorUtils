﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EditorUtils.UnitTest
{
    public sealed class EditorVersionUtilTest
    {
        [Fact]
        public void GetShortVersionStringAll()
        {
            foreach (var e in Enum.GetValues(typeof(EditorVersion)).Cast<EditorVersion>())
            {
                var value = EditorVersionUtil.GetShortVersionString(e);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void GetVersionNumberAll()
        {
            Assert.Equal(10, EditorVersionUtil.GetMajorVersionNumber(EditorVersion.Vs2010));
            Assert.Equal(11, EditorVersionUtil.GetMajorVersionNumber(EditorVersion.Vs2012));
            Assert.Equal(12, EditorVersionUtil.GetMajorVersionNumber(EditorVersion.Vs2013));
            Assert.Equal(14, EditorVersionUtil.GetMajorVersionNumber(EditorVersion.Vs2015));
            Assert.Equal(15, EditorVersionUtil.GetMajorVersionNumber(EditorVersion.Vs2017));
        }

        [Fact]
        public void MaxEditorVersionIsMax()
        {
            var max = EditorVersionUtil.GetMajorVersionNumber(EditorVersionUtil.MaxVersion);
            foreach (var e in Enum.GetValues(typeof(EditorVersion)).Cast<EditorVersion>())
            {
                var number = EditorVersionUtil.GetMajorVersionNumber(e);
                Assert.True(number <= max);
            }
        }
    }
}
