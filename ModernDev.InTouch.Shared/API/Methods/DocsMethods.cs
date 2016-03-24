/**
 * This file\code is part of InTouch project.
 *
 * InTouch - is a .NET wrapper for the vk.com API.
 * https://github.com/virtyaluk/InTouch
 *
 * Copyright (c) 2016 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Provides a base class for managing user's documents.
    /// </summary>
    public class DocsMethods : MethodsGroup
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocsMethods"/> class with a given <see cref="InTouch"/> instance.
        /// </summary>
        /// <param name="api">An instance of <see cref="InTouch"/> class.</param>
        public DocsMethods(InTouch api) : base(api, "docs") { }

        #endregion

        #region Methods

        /// <summary>
        /// Returns detailed information about user or community documents.
        /// </summary>
        /// <param name="count">Number of documents to return. By default, all documents.</param>
        /// <param name="offset">Offset needed to return a specific subset of documents.</param>
        /// <param name="type">The type to filter on.</param>
        /// <param name="ownerId">ID of the user or community that owns the documents. Use a negative value to designate a community ID. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Doc"/> objects.</returns>
        public async Task<Response<ItemsList<Doc>>> Get(int? count = null, int? offset = null,
            DocTypes type = DocTypes.Undefined, int? ownerId = null)
            => await Request<ItemsList<Doc>>("get", new MethodParams
            {
                {"count", count},
                {"offset", offset},
                {"type", (int) type},
                {"owner_id", ownerId}
            });

        /// <summary>
        /// Returns information about documents by their IDs.
        /// </summary>
        /// <param name="docs">Document IDs separated by commas.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Doc"/> objects.</returns>
        public async Task<Response<List<Doc>>> GetById(string docs)
            => await Request<List<Doc>>("getById", new MethodParams {{"docs", docs, true}});

        /// <summary>
        /// Returns information about documents by their IDs.
        /// </summary>
        /// <param name="docs">A list of document IDs.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Doc"/> objects.</returns>
        public async Task<Response<List<Doc>>> GetById(List<string> docs) => await GetById(string.Join(",", docs));

        /// <summary>
        /// Returns the server address for document upload.
        /// </summary>
        /// <param name="groupId">Community ID (if the document will be uploaded to the community). </param>
        /// <returns>Returns a <see cref="ServerInfo"/> object with an <see cref="ServerInfo.UploadUrl"/> field. After the document is uploaded, use the <see cref="Save"/> method.</returns>
        public async Task<Response<ServerInfo>> GetUploadServer(int? groupId = null)
            => await Request<ServerInfo>("getUploadServer", new MethodParams {{"group_id", groupId}});

        /// <summary>
        /// Returns the server address for document upload onto a user's or community's wall.
        /// </summary>
        /// <param name="groupId">Community ID (if the document will be uploaded to the community).</param>
        /// <returns>Returns a <see cref="ServerInfo"/> object with an <see cref="ServerInfo.UploadUrl"/> field. After the document is uploaded, use the <see cref="Save"/> method.</returns>
        public async Task<Response<ServerInfo>> GetWallUploadServer(int? groupId = null)
            => await Request<ServerInfo>("getWallUploadServer", new MethodParams {{"group_id", groupId}});

        /// <summary>
        /// Saves a document after uploading it to a server.
        /// </summary>
        /// <param name="file">This parameter is returned when the file is uploaded to the server. </param>
        /// <param name="title">Document title.</param>
        /// <param name="tags">Document tags. </param>
        /// <returns>Returns a <see cref="List{T}"/> of uploaded <see cref="Doc"/> objects.</returns>
        public async Task<Response<List<Doc>>> Save(string file, string title = null, string tags = null)
            => await Request<List<Doc>>("save", new MethodParams
            {
                {"file", file, true},
                {"title", title},
                {"tags", tags}
            });

        /// <summary>
        /// Deletes a user or community document.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the document. Use a negative value to designate a community ID. </param>
        /// <param name="docId">Document ID. </param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> Delete(int ownerId, int docId)
            => await Request<bool>("delete", new MethodParams {{"owner_id", ownerId, true}, {"doc_id", docId, true}});

        /// <summary>
        /// Copies a document to a user's or community's document list.
        /// </summary>
        /// <param name="ownerId">ID of the user or community that owns the document. Use a negative value to designate a community ID.</param>
        /// <param name="docId">Document ID.</param>
        /// <param name="accessKey">Access key. This parameter is required if <see cref="Doc.AccessKey"/> was returned with the document's data. </param>
        /// <returns>Returns the ID of the created document (<see cref="Doc.Id"/>).</returns>
        public async Task<Response<int>> Add(int ownerId, int docId, string accessKey = null)
            => await Request<int>("add", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"doc_id", docId, true},
                {"access_key", accessKey}
            });

        /// <summary>
        /// Gets the available types of documents for the user.
        /// </summary>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="DocType"/> objects.</returns>
        public async Task<Response<ItemsList<DocType>>> GetTypes(int ownerId)
            => await Request<ItemsList<DocType>>("getTypes", new MethodParams {{"owner_id", ownerId, true}});

        /// <summary>
        /// Returns a list of documents matching the search criteria.
        /// </summary>
        /// <param name="q">Search query string.</param>
        /// <param name="offset">Offset needed to return a specific subset of docs.</param>
        /// <param name="count">Number of docs to return. </param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Doc"/> objects.</returns>
        public async Task<Response<ItemsList<Doc>>> Search(string q, int? offset = null, int? count = null)
            => await Request<ItemsList<Doc>>("search", new MethodParams
            {
                {"q", q, true},
                {"offset", offset},
                {"count", count}
            });

        /// <summary>
        /// Edits a document.
        /// </summary>
        /// <param name="ownerId">User ID or community ID. Use a negative value to designate a community ID.</param>
        /// <param name="docId">Document ID.</param>
        /// <param name="title">Document title. </param>
        /// <param name="tags">Document tags.</param>
        /// <returns>When executed successfully it returns True.</returns>
        public async Task<Response<bool>> Edit(int ownerId, int docId, string title = null, string tags = null)
            => await Request<bool>("edit", new MethodParams
            {
                {"owner_id", ownerId, true},
                {"doc_id", docId, true},
                {"title", title},
                {"tags", tags}
            });

        #region Upload methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docData">Document data.</param>
        /// <param name="fileName">Document file name.</param>
        /// <param name="isWallDoc">True - to upload a doc to the wall.</param>
        /// <param name="groupId">Community ID (if the document will be uploaded to the community).</param>
        /// <param name="title">Document title.</param>
        /// <param name="tags">Document tags. </param>
        /// <exception cref="ArgumentNullException">Thrown when a <c>docData</c> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a <c>fileName</c> is null.</exception>
        /// <exception cref="InTouchException">Thrown when an exception has occurred while uploading the file.</exception>
        /// <returns>Returns a <see cref="List{T}"/> of uploaded <see cref="Doc"/> objects.</returns>
        public async Task<Response<List<Doc>>> UploadDoc(byte[] docData, string fileName, bool isWallDoc = false,
            int? groupId = null,
            string title = null, string tags = null)
        {
            if (docData == null)
            {
                throw new ArgumentNullException(nameof(docData));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                var uplServerResp = await (isWallDoc ? GetWallUploadServer(groupId) : GetUploadServer(groupId));

                if (uplServerResp.IsError && !API.ThrowExceptionOnResponseError)
                {
                    throw new InTouchResponseErrorException(uplServerResp.Error.Message, uplServerResp.Error);
                }

                var uplRespRawJson = await API.UploadFile(uplServerResp.Data.UploadUrl,
                    new List<Tuple<string, byte[], string>>
                    {
                        {"file", docData, fileName}
                    });
                var uplServerData = API.ParseUploadServerResponse<DocUploadResponse>(uplRespRawJson);

                return await Save(uplServerData.File, title, tags);
            }
            catch (Exception ex)
            {
                throw new InTouchException("An exception has occurred while uploading document.", ex);
            }
        }

        #endregion

        #endregion
    }
}