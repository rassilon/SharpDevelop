﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using ICSharpCode.PythonBinding;
using ICSharpCode.SharpDevelop.Dom;
using NUnit.Framework;
using PythonBinding.Tests.Utils;

namespace PythonBinding.Tests.Resolver
{
	[TestFixture]
	public class ResolveSystemNamespaceWithMissingImportTestFixture : ResolveTestFixtureBase
	{
		protected override ExpressionResult GetExpressionResult()
		{
			MockClass systemConsoleClass = new MockClass(projectContent, "System.Console");
			List<ICompletionEntry> namespaceItems = new List<ICompletionEntry>();
			namespaceItems.Add(systemConsoleClass);
			projectContent.AddExistingNamespaceContents("System", namespaceItems);

			return new ExpressionResult("System", ExpressionContext.Default);
		}
		
		protected override string GetPythonScript()
		{
			return "System\r\n";
		}
		
		[Test]
		public void ResolveResultIsNullSinceSystemNamespaceIsNotImported()
		{
			Assert.IsNull(resolveResult);
		}
		
		[Test]
		public void ProjectContentNamespaceExistsReturnsTrueForSystemNamespace()
		{
			Assert.IsTrue(projectContent.NamespaceExists("System"));
		}
	}
}