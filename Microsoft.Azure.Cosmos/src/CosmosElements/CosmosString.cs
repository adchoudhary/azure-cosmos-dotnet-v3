﻿//-----------------------------------------------------------------------
// <copyright file="CosmosString.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.CosmosElements
{
    using Microsoft.Azure.Cosmos.CosmosElements.Patchable;
    using Microsoft.Azure.Cosmos.Json;

    internal abstract partial class CosmosString : CosmosElement
    {
        protected CosmosString()
            : base(CosmosElementType.String)
        {
        }

        public abstract string Value
        {
            get;
        }

        public override PatchableCosmosElement ToPatchable()
        {
            return PatchableCosmosString.Create(this);
        }

        public static CosmosString Create(
            IJsonNavigator jsonNavigator,
            IJsonNavigatorNode jsonNavigatorNode)
        {
            return new LazyCosmosString(jsonNavigator, jsonNavigatorNode);
        }

        public static CosmosString Create(string value)
        {
            return new EagerCosmosString(value);
        }
    }
}
